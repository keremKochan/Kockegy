using BusinessLayer.Concrete;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kockegy.Controllers
{
    public class UrunController : Controller
    {
        // GET: Kategori
        UrunRepository urunRepository = new UrunRepository();
        DataContext db = new DataContext();

        public ActionResult UrunDetay(int id)
        {
            var details = urunRepository.GetById(id);
            //var yorum = db.Yorums.Where(x => x.UrunId == id).ToList();
            //ViewBag.yorum = yorum;

            return View(details);
        }


        [HttpPost]
        public ActionResult Yorum(Yorum data)
        {
            if (User.Identity.IsAuthenticated)
            {
                //db.Yorums.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Hesap");
        }

        public ActionResult PopulerUrunler()
        {
            var urun = urunRepository.GetPopulerUrun();
            ViewBag.populer = urun;
            return View();
        }

    }
}