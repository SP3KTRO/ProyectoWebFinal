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
    public class tel_clienteController : Controller
    {
        private proyectowebEntities db = new proyectowebEntities();

        // GET: tel_cliente
        public ActionResult Index()
        {
            var tel_cliente = db.tel_cliente.Include(t => t.cliente);
            return View(tel_cliente.ToList());
        }

        // GET: tel_cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tel_cliente tel_cliente = db.tel_cliente.Find(id);
            if (tel_cliente == null)
            {
                return HttpNotFound();
            }
            return View(tel_cliente);
        }

        // GET: tel_cliente/Create
        public ActionResult Create()
        {
            ViewBag.cedula = new SelectList(db.cliente, "cedula", "nombre");
            return View();
        }

        // POST: tel_cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cedula,telefono")] tel_cliente tel_cliente)
        {
            if (ModelState.IsValid)
            {
                db.tel_cliente.Add(tel_cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cedula = new SelectList(db.cliente, "cedula", "nombre", tel_cliente.cedula);
            return View(tel_cliente);
        }

        // GET: tel_cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tel_cliente tel_cliente = db.tel_cliente.Find(id);
            if (tel_cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.cedula = new SelectList(db.cliente, "cedula", "nombre", tel_cliente.cedula);
            return View(tel_cliente);
        }

        // POST: tel_cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cedula,telefono")] tel_cliente tel_cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tel_cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cedula = new SelectList(db.cliente, "cedula", "nombre", tel_cliente.cedula);
            return View(tel_cliente);
        }

        // GET: tel_cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tel_cliente tel_cliente = db.tel_cliente.Find(id);
            if (tel_cliente == null)
            {
                return HttpNotFound();
            }
            return View(tel_cliente);
        }

        // POST: tel_cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tel_cliente tel_cliente = db.tel_cliente.Find(id);
            db.tel_cliente.Remove(tel_cliente);
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
