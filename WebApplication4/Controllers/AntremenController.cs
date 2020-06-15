using NHibernate.Criterion;
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
    [Nitelik.OturumKontrol]
    [Nitelik.Log]

    public class AntremenController : Controller
    {
        private antremantakipEntities1 db = new antremantakipEntities1();

        // GET: Antremen


        // GET: Antremen/Create
        
        public ActionResult Create()
        {
            return View();
        }

        // POST: Antremen/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
    
        public ActionResult Create([Bind(Include = "No,Ad,AntremanTurNo")] Antreman antreman)
        {
            
            if (ModelState.IsValid)
            {
                db.Antreman.Add(antreman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(antreman);
        }

       

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
