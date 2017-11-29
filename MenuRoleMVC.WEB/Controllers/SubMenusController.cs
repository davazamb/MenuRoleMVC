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
    public class SubMenusController : Controller
    {
        private PanelMenuRolEntities db = new PanelMenuRolEntities();

        // GET: SubMenus
        public ActionResult Index()
        {
            var tblSubMenu = db.tblSubMenu.Include(t => t.tblMainMenu).Include(t => t.tblPerfil);
            return View(tblSubMenu.ToList());
        }

        // GET: SubMenus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSubMenu tblSubMenu = db.tblSubMenu.Find(id);
            if (tblSubMenu == null)
            {
                return HttpNotFound();
            }
            return View(tblSubMenu);
        }

        // GET: SubMenus/Create
        public ActionResult Create()
        {
            ViewBag.MainMenuId = new SelectList(db.tblMainMenu, "Id", "MainMenu");
            ViewBag.RoleId = new SelectList(db.tblPerfil, "Id", "Perfiles");
            return View();
        }

        // POST: SubMenus/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SubMenu,Controller,Action,MainMenuId,RoleId")] tblSubMenu tblSubMenu)
        {
            if (ModelState.IsValid)
            {
                db.tblSubMenu.Add(tblSubMenu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MainMenuId = new SelectList(db.tblMainMenu, "Id", "MainMenu", tblSubMenu.MainMenuId);
            ViewBag.RoleId = new SelectList(db.tblPerfil, "Id", "Perfiles", tblSubMenu.RoleId);
            return View(tblSubMenu);
        }

        // GET: SubMenus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSubMenu tblSubMenu = db.tblSubMenu.Find(id);
            if (tblSubMenu == null)
            {
                return HttpNotFound();
            }
            ViewBag.MainMenuId = new SelectList(db.tblMainMenu, "Id", "MainMenu", tblSubMenu.MainMenuId);
            ViewBag.RoleId = new SelectList(db.tblPerfil, "Id", "Perfiles", tblSubMenu.RoleId);
            return View(tblSubMenu);
        }

        // POST: SubMenus/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SubMenu,Controller,Action,MainMenuId,RoleId")] tblSubMenu tblSubMenu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSubMenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MainMenuId = new SelectList(db.tblMainMenu, "Id", "MainMenu", tblSubMenu.MainMenuId);
            ViewBag.RoleId = new SelectList(db.tblPerfil, "Id", "Perfiles", tblSubMenu.RoleId);
            return View(tblSubMenu);
        }

        // GET: SubMenus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSubMenu tblSubMenu = db.tblSubMenu.Find(id);
            if (tblSubMenu == null)
            {
                return HttpNotFound();
            }
            return View(tblSubMenu);
        }

        // POST: SubMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSubMenu tblSubMenu = db.tblSubMenu.Find(id);
            db.tblSubMenu.Remove(tblSubMenu);
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
