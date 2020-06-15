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
   
    public class AntremanProgramsController : Controller
    {
        private antremantakipEntities1 db = new antremantakipEntities1();

        // GET: AntremanPrograms
        [Nitelik.OturumKontrol]
        public ActionResult Index()
        {
            var antremanProgram = db.AntremanProgram.Include(a => a.Antreman);
            return View(antremanProgram.ToList());
        }

        // GET: AntremanPrograms/Details/5
        [Nitelik.OturumKontrol]
        [Nitelik.Log]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AntremanProgram antremanProgram = db.AntremanProgram.Find(id);
            if (antremanProgram == null)
            {
                return HttpNotFound();
            }
            return View(antremanProgram);
        }

        // GET: AntremanPrograms/Create
        [Nitelik.OturumKontrol]
        public ActionResult Create()
        {
            ViewBag.AntremanNo = new SelectList(db.Antreman, "No", "Ad");
            return View();
        }

        // POST: AntremanPrograms/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Nitelik.OturumKontrol]
        public ActionResult Create([Bind(Include = "No,AntremanNo,AntremanBaslama,AntremanBitis,GunNo")] AntremanProgram antremanProgram)
        {
            if (ModelState.IsValid)
            {
                db.AntremanProgram.Add(antremanProgram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AntremanNo = new SelectList(db.Antreman, "No", "Ad", antremanProgram.AntremanNo);
            return View(antremanProgram);
        }

        // GET: AntremanPrograms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AntremanProgram antremanProgram = db.AntremanProgram.Find(id);
            if (antremanProgram == null)
            {
                return HttpNotFound();
            }
            ViewBag.AntremanNo = new SelectList(db.Antreman, "No", "Ad", antremanProgram.AntremanNo);
            return View(antremanProgram);
        }

        // POST: AntremanPrograms/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "No,AntremanNo,AntremanBaslama,AntremanBitis,GunNo")] AntremanProgram antremanProgram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(antremanProgram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AntremanNo = new SelectList(db.Antreman, "No", "Ad", antremanProgram.AntremanNo);
            return View(antremanProgram);
        }

        // GET: AntremanPrograms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AntremanProgram antremanProgram = db.AntremanProgram.Find(id);
            if (antremanProgram == null)
            {
                return HttpNotFound();
            }
            return View(antremanProgram);
        }

        // POST: AntremanPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AntremanProgram antremanProgram = db.AntremanProgram.Find(id);
            db.AntremanProgram.Remove(antremanProgram);
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
