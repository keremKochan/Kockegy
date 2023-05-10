using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Kockegy.Controllers
{
    public class HesapController : Controller
    {
        // GET: Hesap
        DataContext db = new DataContext();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Kullanici data)
        {
            var bilgiler = db.Kullanicis.FirstOrDefault(x => x.Email == data.Email && x.Sifre == data.Sifre);

            try
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Email, false);

                Session["Mail"] = bilgiler.Email.ToString();
                Session["Ad"] = bilgiler.Ad.ToString();
                Session["Soyad"] = bilgiler.Soyad.ToString();
                Session["userid"] = bilgiler.Id.ToString();
                Thread.Sleep(1000);
                return RedirectToActionPermanent("Index", "Home");
            }
            catch (Exception)
            {
                TempData["Mesaj"] = "Mail veya Şifreniz Hatalı";
            }
            return View(data);
        }


        [HttpPost]
        public ActionResult Kayit(Kullanici data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Kullanicis.Add(data);
                    data.Rol = "Kullanıcı";
                    db.SaveChanges();
                    TempData["Mesaj2"] = "Kayıt işlemi başarılı giriş yapabilirsiniz.";
                }
                catch (Exception)
                {
                    TempData["Mesaj2"] = "Mesajını gönderilemedi. Hata nedeni: ";
                }
                return RedirectToAction("Login");
            }



            return View("Login", data);
        }


        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}