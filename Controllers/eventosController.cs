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
    public class eventosController : Controller
    {
        private proyectowebEntities db = new proyectowebEntities();

        // GET: eventos
        public ActionResult Index()
        {
            var evento = db.evento.Include(e => e.trabajador).Include(e => e.lugar).Include(e => e.tipo);
            return View(evento.ToList());
        }

        // GET: eventos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento evento = db.evento.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // GET: eventos/Create
        public ActionResult Create()
        {
            ViewBag.codigo_tra = new SelectList(db.trabajador, "codigo", "nombre");
            ViewBag.id_lugar = new SelectList(db.lugar, "id_lugar", "lugar1");
            ViewBag.id_tipo = new SelectList(db.tipo, "id_tipo", "tipo1");
            return View();
        }

        // POST: eventos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_evento,nombre,id_tipo,id_lugar,descripcion,fecha,codigo_tra")] evento evento)
        {
            if (ModelState.IsValid)
            {
                db.evento.Add(evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigo_tra = new SelectList(db.trabajador, "codigo", "nombre", evento.codigo_tra);
            ViewBag.id_lugar = new SelectList(db.lugar, "id_lugar", "lugar1", evento.id_lugar);
            ViewBag.id_tipo = new SelectList(db.tipo, "id_tipo", "tipo1", evento.id_tipo);
            return View(evento);
        }

        // GET: eventos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento evento = db.evento.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigo_tra = new SelectList(db.trabajador, "codigo", "nombre", evento.codigo_tra);
            ViewBag.id_lugar = new SelectList(db.lugar, "id_lugar", "lugar1", evento.id_lugar);
            ViewBag.id_tipo = new SelectList(db.tipo, "id_tipo", "tipo1", evento.id_tipo);
            return View(evento);
        }

        // POST: eventos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_evento,nombre,id_tipo,id_lugar,descripcion,fecha,codigo_tra")] evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigo_tra = new SelectList(db.trabajador, "codigo", "nombre", evento.codigo_tra);
            ViewBag.id_lugar = new SelectList(db.lugar, "id_lugar", "lugar1", evento.id_lugar);
            ViewBag.id_tipo = new SelectList(db.tipo, "id_tipo", "tipo1", evento.id_tipo);
            return View(evento);
        }

        // GET: eventos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento evento = db.evento.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            evento evento = db.evento.Find(id);
            db.evento.Remove(evento);
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
