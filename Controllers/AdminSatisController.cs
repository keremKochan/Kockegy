using DataAccessLayer.Context;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kockegy.Controllers
{
    public class AdminSatisController : Controller
    {
        // GET: AdminSatis
        DataContext db = new DataContext();
        public ActionResult Index(int sayfa = 1)
        {
            return View(db.Satis.ToList().ToPagedList(sayfa, 5));
        }
    }
}