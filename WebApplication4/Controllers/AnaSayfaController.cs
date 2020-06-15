using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Nitelik.Log]
    public class AnaSayfaController : Controller
    {
        private antremantakipEntities1 db = new antremantakipEntities1();

        // GET: AnaSayfa
        public ActionResult Index()
        {
            return View(db.Duyuru.ToList());
        }

        // GET: AnaSayfa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duyuru duyuru = db.Duyuru.Find(id);
            if (duyuru == null)
            {
                return HttpNotFound();
            }
            return View(duyuru);
        }

        // GET: AnaSayfa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnaSayfa/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "No,DuyuruBaslik,DuyuruMetin,tarih")] Duyuru duyuru)
        {
            if (ModelState.IsValid)
            {
                db.Duyuru.Add(duyuru);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(duyuru);
        }

        // GET: AnaSayfa/Edit/5
       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
