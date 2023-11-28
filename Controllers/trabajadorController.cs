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
    public class trabajadorController : Controller
    {
        private proyectowebEntities db = new proyectowebEntities();

        // GET: trabajador
        public ActionResult Index()
        {
            var trabajador = db.trabajador.Include(t => t.tel_trabajador);
            return View(trabajador.ToList());
        }

        // GET: trabajador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trabajador trabajador = db.trabajador.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // GET: trabajador/Create
        public ActionResult Create()
        {
            ViewBag.codigo = new SelectList(db.tel_trabajador, "codigo", "codigo");
            return View();
        }

        // POST: trabajador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,nombre,cargo,correo,direccion,fecha_ingreso")] trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                db.trabajador.Add(trabajador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigo = new SelectList(db.tel_trabajador, "codigo", "codigo", trabajador.codigo);
            return View(trabajador);
        }

        // GET: trabajador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trabajador trabajador = db.trabajador.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigo = new SelectList(db.tel_trabajador, "codigo", "codigo", trabajador.codigo);
            return View(trabajador);
        }

        // POST: trabajador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,nombre,cargo,correo,direccion,fecha_ingreso")] trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabajador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigo = new SelectList(db.tel_trabajador, "codigo", "codigo", trabajador.codigo);
            return View(trabajador);
        }

        // GET: trabajador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trabajador trabajador = db.trabajador.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // POST: trabajador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trabajador trabajador = db.trabajador.Find(id);
            db.trabajador.Remove(trabajador);
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
