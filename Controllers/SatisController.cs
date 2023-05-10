using DataAccessLayer.Context;
using EntityLayer.Entities;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kockegy.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        DataContext db = new DataContext();
        public ActionResult Index(int sayfa = 1)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var kullanici = db.Kullanicis.FirstOrDefault(x => x.Email == kullaniciadi);
                var model = db.Satis.Where(x => x.UserId == kullanici.Id).ToList().ToPagedList(sayfa, 5);
                return View(model);
            }
            return HttpNotFound();
        }

        public ActionResult Al(int id)
        {
            var model = db.Sepets.FirstOrDefault(x => x.Id == id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Al2(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = db.Sepets.FirstOrDefault(x => x.Id == id);

                    var satis = new Satis
                    {
                        UserId = model.KullaniciId,
                        UrunId = model.UrunId,
                        Adet = model.Adet,
                        Resim = model.Resim,
                        Ucret = model.Ucret,
                        Tarih = model.Tarih,

                    };
                    db.Sepets.Remove(model);
                    db.Satis.Add(satis);
                    db.SaveChanges();
                    ViewBag.islem = "Satın Alma İşlemi Başarılı Bir Şekilde Gerçekleşmiştir";
                }
            }
            catch (Exception)
            {

                ViewBag.islem = "Satın Alma İşlemi Başarısız ";
            }

            return View("islem");

        }

        public ActionResult HepsiniAl(decimal? Tutar)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var kullanici = db.Kullanicis.FirstOrDefault(x => x.Email == kullaniciadi);
                var model = db.Sepets.Where(x => x.KullaniciId == kullanici.Id).ToList();
                var kid = db.Sepets.FirstOrDefault(x => x.KullaniciId == kullanici.Id);
                if (model != null)
                {
                    if (kid == null)
                    {
                        ViewBag.Tutar = "Sepetinizde ürün bulunmamaktadır";
                    }
                    else if (kid != null)
                    {
                        Tutar = db.Sepets.Where(x => x.KullaniciId == kid.KullaniciId).Sum(x => x.Urun.Fiyat * x.Adet);
                        ViewBag.Tutar = "Toplam Tutar = " + Tutar + "TL";
                    }
                    return View(model);
                }

                return View();
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult HepsiniAl2()
        {
            var username = User.Identity.Name;
            var kullanici = db.Kullanicis.FirstOrDefault(x => x.Email == username);
            var model = db.Sepets.Where(x => x.KullaniciId == kullanici.Id).ToList();
            int row = 0;
            foreach (var item in model)
            {
                var satis = new Satis
                {
                    UserId = model[row].KullaniciId,
                    UrunId = model[row].UrunId,
                    Adet = model[row].Adet,
                    Ucret = model[row].Ucret,
                    Resim = model[row].Urun.Resim,
                    Tarih = DateTime.Now
                };
                db.Satis.Add(satis);
                db.SaveChanges();
                row++;
            }
            db.Sepets.RemoveRange(model);
            db.SaveChanges();
            return RedirectToAction("Index", "Sepet");
        }


    }
}