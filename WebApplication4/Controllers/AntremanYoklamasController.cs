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
    
   
    public class AntremanYoklamasController : Controller
    {
        private antremantakipEntities1 db = new antremantakipEntities1();

        // GET: AntremanYoklamas
        public ActionResult Index()
        {
            var antremanYoklama = db.AntremanYoklama.Include(a => a.AntremanProgram).Include(a => a.Kullanici);
            return View(antremanYoklama.ToList());
        }

        // GET: AntremanYoklamas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AntremanYoklama antremanYoklama = db.AntremanYoklama.Find(id);
            if (antremanYoklama == null)
            {
                return HttpNotFound();
            }
            return View(antremanYoklama);
        }

        // GET: AntremanYoklamas/Create
        [Nitelik.OturumKontrol]
        [Nitelik.Log]
        [Authorize(Roles = "Yönetici")]
        public ActionResult Create()
        {
            ViewBag.AntremanProgramNo = new SelectList(db.AntremanProgram, "No", "No");
            ViewBag.KullaniciNo = new SelectList(db.Kullanici, "No", "Ad");
            return View();
        }

        // POST: AntremanYoklamas/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Nitelik.OturumKontrol]
        public ActionResult Create([Bind(Include = "No,AntremanProgramNo,KullaniciNo,Tarih")] AntremanYoklama antremanYoklama)
        {
            if (ModelState.IsValid)
            {
                db.AntremanYoklama.Add(antremanYoklama);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AntremanProgramNo = new SelectList(db.AntremanProgram, "No", "No", antremanYoklama.AntremanProgramNo);
            ViewBag.KullaniciNo = new SelectList(db.Kullanici, "No", "Ad", antremanYoklama.KullaniciNo);
            return View(antremanYoklama);
        }

        // GET: AntremanYoklamas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AntremanYoklama antremanYoklama = db.AntremanYoklama.Find(id);
            if (antremanYoklama == null)
            {
                return HttpNotFound();
            }
            ViewBag.AntremanProgramNo = new SelectList(db.AntremanProgram, "No", "No", antremanYoklama.AntremanProgramNo);
            ViewBag.KullaniciNo = new SelectList(db.Kullanici, "No", "Ad", antremanYoklama.KullaniciNo);
            return View(antremanYoklama);
        }

        // POST: AntremanYoklamas/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "No,AntremanProgramNo,KullaniciNo,Tarih")] AntremanYoklama antremanYoklama)
        {
            if (ModelState.IsValid)
            {
                db.Entry(antremanYoklama).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AntremanProgramNo = new SelectList(db.AntremanProgram, "No", "No", antremanYoklama.AntremanProgramNo);
            ViewBag.KullaniciNo = new SelectList(db.Kullanici, "No", "Ad", antremanYoklama.KullaniciNo);
            return View(antremanYoklama);
        }

        // GET: AntremanYoklamas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AntremanYoklama antremanYoklama = db.AntremanYoklama.Find(id);
            if (antremanYoklama == null)
            {
                return HttpNotFound();
            }
            return View(antremanYoklama);
        }

        // POST: AntremanYoklamas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AntremanYoklama antremanYoklama = db.AntremanYoklama.Find(id);
            db.AntremanYoklama.Remove(antremanYoklama);
            db.SaveChanges();
            return RedirectToAction("Index");
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
