using BusinessLayer.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kockegy.Controllers
{
    public class AdminKategoriController : Controller
    {
        // GET: AdminKategori
        KategoriRepository kategoriRepository = new KategoriRepository();
        public ActionResult Index()
        {
            return View(kategoriRepository.List());
        }

        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Kategori p)
        {
            if (ModelState.IsValid)
            {
                kategoriRepository.Insert(p);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Bir Hata Oluştu");
            return View();
        }
        public ActionResult Delete(int id)
        {
            var delete = kategoriRepository.GetById(id);
            kategoriRepository.Delete(delete);
            return RedirectToAction("Index");
        }


        public ActionResult Update(int id)
        {
            var update = kategoriRepository.GetById(id);
            return View(update);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(Kategori p)
        {
            if (ModelState.IsValid)
            {
                var update = kategoriRepository.GetById(p.Id);
                update.Ad = p.Ad;
                update.Aciklama = p.Aciklama;
                kategoriRepository.Update(update);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Bir Hata Oluştu");
            return View();
        }
    }
}