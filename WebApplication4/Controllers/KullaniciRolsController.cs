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
    public class KullaniciRolsController : Controller
    {
        private antremantakipEntities1 db = new antremantakipEntities1();

        // GET: KullaniciRols
        public ActionResult Index()
        {
            var kullaniciRol = db.KullaniciRol.Include(k => k.Rol);
            return View(kullaniciRol.ToList());
        }

        // GET: KullaniciRols/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KullaniciRol kullaniciRol = db.KullaniciRol.Find(id);
            if (kullaniciRol == null)
            {
                return HttpNotFound();
            }
            return View(kullaniciRol);
        }

        // GET: KullaniciRols/Create
        public ActionResult Create()
        {
            ViewBag.RolNo = new SelectList(db.Rol, "No", "Ad");
            return View();
        }

        // POST: KullaniciRols/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "No,KullaniciNo,RolNo")] KullaniciRol kullaniciRol)
        {
            if (ModelState.IsValid)
            {
                db.KullaniciRol.Add(kullaniciRol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RolNo = new SelectList(db.Rol, "No", "Ad", kullaniciRol.RolNo);
            return View(kullaniciRol);
        }

        // GET: KullaniciRols/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KullaniciRol kullaniciRol = db.KullaniciRol.Find(id);
            if (kullaniciRol == null)
            {
                return HttpNotFound();
            }
            ViewBag.RolNo = new SelectList(db.Rol, "No", "Ad", kullaniciRol.RolNo);
            return View(kullaniciRol);
        }

        // POST: KullaniciRols/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "No,KullaniciNo,RolNo")] KullaniciRol kullaniciRol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kullaniciRol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RolNo = new SelectList(db.Rol, "No", "Ad", kullaniciRol.RolNo);
            return View(kullaniciRol);
        }

        // GET: KullaniciRols/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KullaniciRol kullaniciRol = db.KullaniciRol.Find(id);
            if (kullaniciRol == null)
            {
                return HttpNotFound();
            }
            return View(kullaniciRol);
        }

        // POST: KullaniciRols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KullaniciRol kullaniciRol = db.KullaniciRol.Find(id);
            db.KullaniciRol.Remove(kullaniciRol);
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
