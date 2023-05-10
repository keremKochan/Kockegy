using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.Context;
using EntityLayer.Entities;

namespace Kockegy.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            var uruns = db
                .Uruns
                .Where(i => i.Onaylimi == true && i.Populer == true).ToList();
            return View(uruns);
        }

        public PartialViewResult Partial1()
        {
            var uruns = db  
                .Uruns
                .Where(i => i.Populer == true).Take(3).ToList();
            return PartialView(uruns);
        }

        public PartialViewResult Partial2()
        {
            var degerler = db.Uruns.Take(10).ToList();
            return PartialView(degerler);
        }
        
        public ActionResult Magaza()
        {
            var urunler = db.Uruns.Take(9).ToList();
            return View(urunler);
        }


    }
}