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
    public class MetotRolsController : Controller
    {
        private antremantakipEntities1 db = new antremantakipEntities1();

        // GET: MetotRols
        public ActionResult Index()
        {
            var metotRol = db.MetotRol.Include(m => m.Metot).Include(m => m.Rol);
            return View(metotRol.ToList());
        }

        // GET: MetotRols/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetotRol metotRol = db.MetotRol.Find(id);
            if (metotRol == null)
            {
                return HttpNotFound();
            }
            return View(metotRol);
        }

        // GET: MetotRols/Create
        public ActionResult Create()
        {
            ViewBag.MetotNo = new SelectList(db.Metot, "No", "Ad");
            ViewBag.RolNo = new SelectList(db.Rol, "No", "Ad");
            return View();
        }

        // POST: MetotRols/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "No,MetotNo,RolNo")] MetotRol metotRol)
        {
            if (ModelState.IsValid)
            {
                db.MetotRol.Add(metotRol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MetotNo = new SelectList(db.Metot, "No", "Ad", metotRol.MetotNo);
            ViewBag.RolNo = new SelectList(db.Rol, "No", "Ad", metotRol.RolNo);
            return View(metotRol);
        }

        // GET: MetotRols/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetotRol metotRol = db.MetotRol.Find(id);
            if (metotRol == null)
            {
                return HttpNotFound();
            }
            ViewBag.MetotNo = new SelectList(db.Metot, "No", "Ad", metotRol.MetotNo);
            ViewBag.RolNo = new SelectList(db.Rol, "No", "Ad", metotRol.RolNo);
            return View(metotRol);
        }

        // POST: MetotRols/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "No,MetotNo,RolNo")] MetotRol metotRol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metotRol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MetotNo = new SelectList(db.Metot, "No", "Ad", metotRol.MetotNo);
            ViewBag.RolNo = new SelectList(db.Rol, "No", "Ad", metotRol.RolNo);
            return View(metotRol);
        }

        // GET: MetotRols/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetotRol metotRol = db.MetotRol.Find(id);
            if (metotRol == null)
            {
                return HttpNotFound();
            }
            return View(metotRol);
        }

        // POST: MetotRols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MetotRol metotRol = db.MetotRol.Find(id);
            db.MetotRol.Remove(metotRol);
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
