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
    public class estadisticas_eventoController : Controller
    {
        private proyectowebEntities db = new proyectowebEntities();

        // GET: estadisticas_evento
        public ActionResult Index()
        {
            var estadisticas_evento = db.estadisticas_evento.Include(e => e.cliente).Include(e => e.evento);
            return View(estadisticas_evento.ToList());
        }

        // GET: estadisticas_evento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estadisticas_evento estadisticas_evento = db.estadisticas_evento.Find(id);
            if (estadisticas_evento == null)
            {
                return HttpNotFound();
            }
            return View(estadisticas_evento);
        }

        // GET: estadisticas_evento/Create
        public ActionResult Create()
        {
            ViewBag.cedula_cli = new SelectList(db.cliente, "cedula", "nombre");
            ViewBag.id_evento = new SelectList(db.evento, "id_evento", "nombre");
            return View();
        }

        // POST: estadisticas_evento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_estadisticas,puntuacion,id_evento,fecha_compra,cedula_cli")] estadisticas_evento estadisticas_evento)
        {
            if (ModelState.IsValid)
            {
                db.estadisticas_evento.Add(estadisticas_evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cedula_cli = new SelectList(db.cliente, "cedula", "nombre", estadisticas_evento.cedula_cli);
            ViewBag.id_evento = new SelectList(db.evento, "id_evento", "nombre", estadisticas_evento.id_evento);
            return View(estadisticas_evento);
        }

        // GET: estadisticas_evento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estadisticas_evento estadisticas_evento = db.estadisticas_evento.Find(id);
            if (estadisticas_evento == null)
            {
                return HttpNotFound();
            }
            ViewBag.cedula_cli = new SelectList(db.cliente, "cedula", "nombre", estadisticas_evento.cedula_cli);
            ViewBag.id_evento = new SelectList(db.evento, "id_evento", "nombre", estadisticas_evento.id_evento);
            return View(estadisticas_evento);
        }

        // POST: estadisticas_evento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_estadisticas,puntuacion,id_evento,fecha_compra,cedula_cli")] estadisticas_evento estadisticas_evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadisticas_evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cedula_cli = new SelectList(db.cliente, "cedula", "nombre", estadisticas_evento.cedula_cli);
            ViewBag.id_evento = new SelectList(db.evento, "id_evento", "nombre", estadisticas_evento.id_evento);
            return View(estadisticas_evento);
        }

        // GET: estadisticas_evento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estadisticas_evento estadisticas_evento = db.estadisticas_evento.Find(id);
            if (estadisticas_evento == null)
            {
                return HttpNotFound();
            }
            return View(estadisticas_evento);
        }

        // POST: estadisticas_evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            estadisticas_evento estadisticas_evento = db.estadisticas_evento.Find(id);
            db.estadisticas_evento.Remove(estadisticas_evento);
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
