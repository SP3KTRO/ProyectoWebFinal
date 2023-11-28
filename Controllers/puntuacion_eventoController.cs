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
    public class puntuacion_eventoController : Controller
    {
        private proyectowebEntities db = new proyectowebEntities();

        // GET: puntuacion_evento
        public ActionResult Index()
        {
            var puntuacion_evento = db.puntuacion_evento.Include(p => p.cliente).Include(p => p.evento);
            return View(puntuacion_evento.ToList());
        }

        // GET: puntuacion_evento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            puntuacion_evento puntuacion_evento = db.puntuacion_evento.Find(id);
            if (puntuacion_evento == null)
            {
                return HttpNotFound();
            }
            return View(puntuacion_evento);
        }

        // GET: puntuacion_evento/Create
        public ActionResult Create()
        {
            ViewBag.cedula_cli = new SelectList(db.cliente, "cedula", "nombre");
            ViewBag.id_evento = new SelectList(db.evento, "id_evento", "nombre");
            return View();
        }

        // POST: puntuacion_evento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_puntuacion,puntuacion,comentarios,id_evento,cedula_cli")] puntuacion_evento puntuacion_evento)
        {
            if (ModelState.IsValid)
            {
                db.puntuacion_evento.Add(puntuacion_evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cedula_cli = new SelectList(db.cliente, "cedula", "nombre", puntuacion_evento.cedula_cli);
            ViewBag.id_evento = new SelectList(db.evento, "id_evento", "nombre", puntuacion_evento.id_evento);
            return View(puntuacion_evento);
        }

        // GET: puntuacion_evento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            puntuacion_evento puntuacion_evento = db.puntuacion_evento.Find(id);
            if (puntuacion_evento == null)
            {
                return HttpNotFound();
            }
            ViewBag.cedula_cli = new SelectList(db.cliente, "cedula", "nombre", puntuacion_evento.cedula_cli);
            ViewBag.id_evento = new SelectList(db.evento, "id_evento", "nombre", puntuacion_evento.id_evento);
            return View(puntuacion_evento);
        }

        // POST: puntuacion_evento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_puntuacion,puntuacion,comentarios,id_evento,cedula_cli")] puntuacion_evento puntuacion_evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(puntuacion_evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cedula_cli = new SelectList(db.cliente, "cedula", "nombre", puntuacion_evento.cedula_cli);
            ViewBag.id_evento = new SelectList(db.evento, "id_evento", "nombre", puntuacion_evento.id_evento);
            return View(puntuacion_evento);
        }

        // GET: puntuacion_evento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            puntuacion_evento puntuacion_evento = db.puntuacion_evento.Find(id);
            if (puntuacion_evento == null)
            {
                return HttpNotFound();
            }
            return View(puntuacion_evento);
        }

        // POST: puntuacion_evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            puntuacion_evento puntuacion_evento = db.puntuacion_evento.Find(id);
            db.puntuacion_evento.Remove(puntuacion_evento);
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
