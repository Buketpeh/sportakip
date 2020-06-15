using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Nitelik.Log]
    public class OturumController : Controller
    {
       [HttpGet]
       public ActionResult giris()
        {
            var cerez = Request.Cookies["Oturum"];
            if (cerez != null)
            {
                cerez.Expires = DateTime.Now.AddHours(-1);
                Response.Cookies.Remove("Oturum");
            }
            return View("Giris");
        }
        [HttpPost]
        public ActionResult giris(Kullanici k) {
            antremantakipEntities1 db = new antremantakipEntities1();
            var bilgiler = db.Kullanici.FirstOrDefault(x => x.Ad == k.Ad && x.şifre == k.şifre);
            if(bilgiler != null)
            {
                Models.OturumBilgi oturum = new Models.OturumBilgi();
                oturum.Ad = bilgiler.Ad;
                oturum.No = bilgiler.No;
                oturum.sifre = bilgiler.şifre;
                oturum.Soyad = bilgiler.Soyad;
                JavaScriptSerializer serilestirme = new JavaScriptSerializer();
                string kullanicibilgi = serilestirme.Serialize(oturum);

                FormsAuthenticationTicket bilet = new FormsAuthenticationTicket(
                    1,
                    oturum.Ad,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(5),
                    false,
                    kullanicibilgi);
                string sifreliBilet = FormsAuthentication.Encrypt(bilet);

                HttpCookie cerez = new HttpCookie("Oturum",sifreliBilet);
                cerez.HttpOnly = true;
                cerez.Expires = DateTime.Now.AddMinutes(5);
                Response.Cookies.Add(cerez);
                return RedirectToAction("Index", "AnaSayfa");
          }
            else
            {
                ViewBag.Mesaj = "Geçersiz kullanıcı adı veya şifre";
                return View();
        }}
    }
}