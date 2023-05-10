using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.Helpers;
using System.Net.Mail;

namespace Kockegy.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Iletisim()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Iletisim(string Ad = null, string Email = null, string Konu = null, string Messaj = null)
        {
            WebMail.SmtpServer = "smtp.gmail.com";
            WebMail.EnableSsl = true;
            WebMail.UserName = "keremkochan087@gmail.com";
            WebMail.Password = "kerem321123";
            WebMail.SmtpPort = 587;

            try
            {
                WebMail.Send("keremkochan087@gmail.com", Konu, Email + "</br>" + Messaj);
                TempData["Message"] = "Mesajını Başarılı Bir Şekilde Gönderildi.";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Mesajını gönderilemedi. Hata nedeni: " + ex.Message;
            }
            return View();
        }
    }
}