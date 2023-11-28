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
    public class tel_trabajadorController : Controller
    {
        private proyectowebEntities db = new proyectowebEntities();

        // GET: tel_trabajador
        public ActionResult Index()
        {
            var tel_trabajador = db.tel_trabajador.Include(t => t.trabajador);
            return View(tel_trabajador.ToList());
        }

        // GET: tel_trabajador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tel_trabajador tel_trabajador = db.tel_trabajador.Find(id);
            if (tel_trabajador == null)
            {
                return HttpNotFound();
            }
            return View(tel_trabajador);
        }

        // GET: tel_trabajador/Create
        public ActionResult Create()
        {
            ViewBag.codigo = new SelectList(db.trabajador, "codigo", "nombre");
            return View();
        }

        // POST: tel_trabajador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,telefono")] tel_trabajador tel_trabajador)
        {
            if (ModelState.IsValid)
            {
                db.tel_trabajador.Add(tel_trabajador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigo = new SelectList(db.trabajador, "codigo", "nombre", tel_trabajador.codigo);
            return View(tel_trabajador);
        }

        // GET: tel_trabajador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tel_trabajador tel_trabajador = db.tel_trabajador.Find(id);
            if (tel_trabajador == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigo = new SelectList(db.trabajador, "codigo", "nombre", tel_trabajador.codigo);
            return View(tel_trabajador);
        }

        // POST: tel_trabajador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,telefono")] tel_trabajador tel_trabajador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tel_trabajador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigo = new SelectList(db.trabajador, "codigo", "nombre", tel_trabajador.codigo);
            return View(tel_trabajador);
        }

        // GET: tel_trabajador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tel_trabajador tel_trabajador = db.tel_trabajador.Find(id);
            if (tel_trabajador == null)
            {
                return HttpNotFound();
            }
            return View(tel_trabajador);
        }

        // POST: tel_trabajador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tel_trabajador tel_trabajador = db.tel_trabajador.Find(id);
            db.tel_trabajador.Remove(tel_trabajador);
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
