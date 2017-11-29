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
    public class MainMenusController : Controller
    {
        private PanelMenuRolEntities db = new PanelMenuRolEntities();

        // GET: MainMenus
        public ActionResult Index()
        {
            return View(db.tblMainMenu.ToList());
        }

        // GET: MainMenus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMainMenu tblMainMenu = db.tblMainMenu.Find(id);
            if (tblMainMenu == null)
            {
                return HttpNotFound();
            }
            return View(tblMainMenu);
        }

        // GET: MainMenus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MainMenus/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MainMenu")] tblMainMenu tblMainMenu)
        {
            if (ModelState.IsValid)
            {
                db.tblMainMenu.Add(tblMainMenu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblMainMenu);
        }

        // GET: MainMenus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMainMenu tblMainMenu = db.tblMainMenu.Find(id);
            if (tblMainMenu == null)
            {
                return HttpNotFound();
            }
            return View(tblMainMenu);
        }

        // POST: MainMenus/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MainMenu")] tblMainMenu tblMainMenu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMainMenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblMainMenu);
        }

        // GET: MainMenus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMainMenu tblMainMenu = db.tblMainMenu.Find(id);
            if (tblMainMenu == null)
            {
                return HttpNotFound();
            }
            return View(tblMainMenu);
        }

        // POST: MainMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblMainMenu tblMainMenu = db.tblMainMenu.Find(id);
            db.tblMainMenu.Remove(tblMainMenu);
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
