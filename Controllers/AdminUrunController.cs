using BusinessLayer.Concrete;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace Kockegy.Controllers
{
    public class AdminUrunController : Controller
    {
        // GET: AdminProduct
        UrunRepository urunRepository = new UrunRepository();
        DataContext db = new DataContext();

        public ActionResult Index(int sayfa = 1)
        {
            return View(urunRepository.List().ToPagedList(sayfa, 3));
        }
        public ActionResult Create()
        {
            List<SelectListItem> deger1 = (from i in db.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.Id.ToString()

                                           }).ToList();
            ViewBag.ktgr = deger1;
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Urun data, HttpPostedFileBase File)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Hata Oluştu");
            }

            string path = Path.Combine("~/Content/Image/" + File.FileName);
            File.SaveAs(Server.MapPath(path));
            data.Resim = File.FileName.ToString();
            urunRepository.Insert(data);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var delete = urunRepository.GetById(id);
            urunRepository.Delete(delete);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            List<SelectListItem> deger1 = (from i in db.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.Id.ToString()

                                           }).ToList();
            ViewBag.ktgr = deger1;
            var update = urunRepository.GetById(id);
            return View(update);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(Urun data, HttpPostedFileBase File)
        {
            var update = urunRepository.GetById(data.Id);
            if (!ModelState.IsValid)
            {
                if (File == null)
                {
                    update.Aciklama = data.Aciklama;
                    update.Ad = data.Ad;
                    update.Onaylimi = data.Onaylimi;
                    update.Populer = data.Populer;
                    update.Fiyat = data.Fiyat;
                    update.Stok = data.Stok;
                    update.KategoriId = data.KategoriId;
                    urunRepository.Update(update);
                    return RedirectToAction("Index");
                }
                else
                {
                    update.Aciklama = data.Aciklama;
                    update.Ad = data.Ad;
                    update.Onaylimi = data.Onaylimi;
                    update.Populer = data.Populer;
                    update.Fiyat = data.Fiyat;
                    update.Stok = data.Stok;
                    update.Resim = File.FileName.ToString();
                    update.KategoriId = data.KategoriId;
                    urunRepository.Update(update);
                    return RedirectToAction("Index");
                }
            }
            return View(update);
        }

        public ActionResult KritikStok()
        {
            var kritik = db.Uruns.Where(x => x.Stok <= 10000).ToList();

            return View(kritik);
        }

        public PartialViewResult StokSayisi()
        {
            if (User.Identity.IsAuthenticated)
            {
                var count = db.Uruns.Where(x => x.Stok < 10000).Count();
                ViewBag.count = count;
                var azalan = db.Uruns.Where(x => x.Stok == 50).Count();
                ViewBag.azalan = azalan;

            }
            return PartialView();

        }


    }
}