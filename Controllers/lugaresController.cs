using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoWebFinal.Models;

namespace ProyectoWebFinal.Controllers
{
    public class lugaresController : Controller
    {
        private proyectowebEntities db = new proyectowebEntities();

        // GET: lugares
        public ActionResult Index()
        {
            return View(db.lugar.ToList());
        }

        // GET: lugares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lugar lugar = db.lugar.Find(id);
            if (lugar == null)
            {
                return HttpNotFound();
            }
            return View(lugar);
        }

        // GET: lugares/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lugares/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_lugar,lugar1")] lugar lugar)
        {
            if (ModelState.IsValid)
            {
                db.lugar.Add(lugar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lugar);
        }

        // GET: lugares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lugar lugar = db.lugar.Find(id);
            if (lugar == null)
            {
                return HttpNotFound();
            }
            return View(lugar);
        }

        // POST: lugares/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_lugar,lugar1")] lugar lugar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lugar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lugar);
        }

        // GET: lugares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lugar lugar = db.lugar.Find(id);
            if (lugar == null)
            {
                return HttpNotFound();
            }
            return View(lugar);
        }

        // POST: lugares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lugar lugar = db.lugar.Find(id);
            db.lugar.Remove(lugar);
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
