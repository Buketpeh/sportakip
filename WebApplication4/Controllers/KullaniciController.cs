using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Kullanici
        //antremantakipEntities1 db = new antremantakipEntities1();
        //public ActionResult Giris()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Giris(Kullanici k)
        //{
        //    var bilgiler = db.Kullanici.FirstOrDefault(x => x.Ad == k.Ad && x.TcKimlikNo == k.TcKimlikNo && x.Soyad == k.Soyad);
        //    if(bilgiler != null)
        //    {
        //    FormsAuthentication.SetAuthCookie(bilgiler.Ad, false);
        //     return RedirectToAction("Index","AnaSayfa");
        //    }
        //    else
        //    {
        //        ViewBag.Mesaj = "Geçersiz kullanıcı adı veya şifre";
        //        return View();
        //    }
            
        //}
        //public ActionResult Cikis()
        //{
        //    FormsAuthentication.SignOut();
        //    return View("Giris");
        //}
    }
}