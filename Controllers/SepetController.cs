using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kockegy.Controllers
{
    public class SepetController : Controller
    {
        // GET: Sepet
        DataContext db = new DataContext();
        public ActionResult Index(decimal? Tutar)
        {
            if (User.Identity.IsAuthenticated)
            {
                var username = User.Identity.Name;
                var kullanici = db.Kullanicis.FirstOrDefault(x => x.Email == username);
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
                        ViewBag.Tutar = "Toplam Tutar " + Tutar + "TL";
                    }
                    return View(model);
                }
            }
            return HttpNotFound();

        }

        public ActionResult SepeteEkle(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var model = db.Kullanicis.FirstOrDefault(x => x.Email == kullaniciadi);
                var u = db.Uruns.Find(id);
                var sepet = db.Sepets.FirstOrDefault(x => x.KullaniciId == model.Id && x.UrunId == id);
                if (model != null)
                {
                    if (Session["userid"].ToString() == model.Id.ToString())
                    {
                        if (sepet != null)
                        {
                            sepet.Adet++;
                            sepet.Ucret = u.Fiyat * sepet.Adet;
                            db.SaveChanges();
                            return RedirectToAction("Index", "Sepet");
                        }
                        var s = new Sepet
                        {
                            KullaniciId = model.Id,
                            UrunId = u.Id,
                            Adet = 1,
                            Ucret = u.Fiyat,
                            Tarih = DateTime.Now


                        };
                        db.Sepets.Add(s);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Sepet");
                    }


                }
                return View();



            }
            return HttpNotFound();
        }


        public ActionResult ToplamAdet(int? count)
        {
            if (User.Identity.IsAuthenticated)
            {

                var model = db.Kullanicis.FirstOrDefault(x => x.Email == User.Identity.Name);
                count = db.Sepets.Where(x => x.KullaniciId == model.Id).Count();
                ViewBag.Count = count;
                if (count == 0)
                {
                    ViewBag.Count = "";
                }

                return PartialView();
            }
            return HttpNotFound();
        }


        public ActionResult arttir(int id)
        {
            var model = db.Sepets.Find(id);
            model.Adet++;
            model.Ucret = model.Ucret * model.Adet;
            db.SaveChanges();
            return RedirectToAction("Index", "Sepet");
        }
        public ActionResult azalt(int id)
        {
            var model = db.Sepets.Find(id);
            if (model.Adet == 1)
            {
                db.Sepets.Remove(model);
                db.SaveChanges();
            }
            model.Adet--;
            model.Ucret = model.Ucret * model.Adet;
            db.SaveChanges();
            return RedirectToAction("Index", "Sepet");
        }
        public void DinamikMiktar(int id, int miktari)
        {
            var model = db.Sepets.Find(id);
            model.Adet = miktari;
            model.Ucret = model.Ucret * model.Adet;
            db.SaveChanges();

        }

        public ActionResult Delete(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var model = db.Kullanicis.FirstOrDefault(x => x.Email == User.Identity.Name);
                if (Session["userid"].ToString() == model.Id.ToString())
                {
                    var sil = db.Sepets.Find(id);
                    db.Sepets.Remove(sil);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Sepet");
                }
            }
            return View();

        }

        public ActionResult DeleteRange()
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var model = db.Kullanicis.FirstOrDefault(x => x.Email == kullaniciadi);
                var sil = db.Sepets.Where(x => x.KullaniciId == model.Id);
                db.Sepets.RemoveRange(sil);
                db.SaveChanges();
                return RedirectToAction("Index", "Sepet");
            }
            return HttpNotFound();
        }


    }
}