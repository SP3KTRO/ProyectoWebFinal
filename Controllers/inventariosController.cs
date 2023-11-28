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
    public class inventariosController : Controller
    {
        private proyectowebEntities db = new proyectowebEntities();

        // GET: inventarios
        public ActionResult Index()
        {
            var inventario = db.inventario.Include(i => i.evento);
            return View(inventario.ToList());
        }

        // GET: inventarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inventario inventario = db.inventario.Find(id);
            if (inventario == null)
            {
                return HttpNotFound();
            }
            return View(inventario);
        }

        // GET: inventarios/Create
        public ActionResult Create()
        {
            ViewBag.id_evento = new SelectList(db.evento, "id_evento", "nombre");
            return View();
        }

        // POST: inventarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_inventario,entradas_disponibles,id_evento,precio_entrada")] inventario inventario)
        {
            if (ModelState.IsValid)
            {
                db.inventario.Add(inventario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_evento = new SelectList(db.evento, "id_evento", "nombre", inventario.id_evento);
            return View(inventario);
        }

        // GET: inventarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inventario inventario = db.inventario.Find(id);
            if (inventario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_evento = new SelectList(db.evento, "id_evento", "nombre", inventario.id_evento);
            return View(inventario);
        }

        // POST: inventarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_inventario,entradas_disponibles,id_evento,precio_entrada")] inventario inventario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_evento = new SelectList(db.evento, "id_evento", "nombre", inventario.id_evento);
            return View(inventario);
        }

        // GET: inventarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inventario inventario = db.inventario.Find(id);
            if (inventario == null)
            {
                return HttpNotFound();
            }
            return View(inventario);
        }

        // POST: inventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            inventario inventario = db.inventario.Find(id);
            db.inventario.Remove(inventario);
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
