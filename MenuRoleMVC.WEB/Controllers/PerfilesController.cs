using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MenuRoleMVC.WEB.DataModels;

namespace MenuRoleMVC.WEB.Controllers
{
    public class PerfilesController : Controller
    {
        private PanelMenuRolEntities db = new PanelMenuRolEntities();

        // GET: Perfiles
        public ActionResult Index()
        {
            var tblPerfil = db.tblPerfil.Include(t => t.tblUsuario);
            return View(tblPerfil.ToList());
        }

        // GET: Perfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPerfil tblPerfil = db.tblPerfil.Find(id);
            if (tblPerfil == null)
            {
                return HttpNotFound();
            }
            return View(tblPerfil);
        }

        // GET: Perfiles/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.tblUsuario, "Id", "Usuario");
            return View();
        }

        // POST: Perfiles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Perfiles")] tblPerfil tblPerfil)
        {
            if (ModelState.IsValid)
            {
                db.tblPerfil.Add(tblPerfil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.tblUsuario, "Id", "Usuario", tblPerfil.Id);
            return View(tblPerfil);
        }

        // GET: Perfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPerfil tblPerfil = db.tblPerfil.Find(id);
            if (tblPerfil == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.tblUsuario, "Id", "Usuario", tblPerfil.Id);
            return View(tblPerfil);
        }

        // POST: Perfiles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Perfiles")] tblPerfil tblPerfil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPerfil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.tblUsuario, "Id", "Usuario", tblPerfil.Id);
            return View(tblPerfil);
        }

        // GET: Perfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPerfil tblPerfil = db.tblPerfil.Find(id);
            if (tblPerfil == null)
            {
                return HttpNotFound();
            }
            return View(tblPerfil);
        }

        // POST: Perfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPerfil tblPerfil = db.tblPerfil.Find(id);
            db.tblPerfil.Remove(tblPerfil);
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
