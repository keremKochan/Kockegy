using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kockegy.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Urun
        KategoriRepository kategoriRepository = new KategoriRepository();

        public PartialViewResult KategoriList()
        {
            return PartialView(kategoriRepository.List());
        }

        public ActionResult Details(int id)
        {
            var kat = kategoriRepository.KategoriDetays(id);
            return View(kat);
        }

    }
}