﻿using System;
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
    public class usuariosController : Controller
    {
        private proyectowebEntities db = new proyectowebEntities();

        // GET: usuarios
        public ActionResult Index()
        {
            var usuario = db.usuario.Include(u => u.cliente).Include(u => u.rol).Include(u => u.trabajador);
            return View(usuario.ToList());
        }

        // GET: usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: usuarios/Create
        public ActionResult Create()
        {
            ViewBag.cedula_cli = new SelectList(db.cliente, "cedula", "nombre");
            ViewBag.id_rol = new SelectList(db.rol, "id_rol", "rol1");
            ViewBag.codigo_tra = new SelectList(db.trabajador, "codigo", "nombre");
            return View();
        }

        // POST: usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_usuario,nombre_usuario,id_rol,codigo_tra,cedula_cli")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cedula_cli = new SelectList(db.cliente, "cedula", "nombre", usuario.cedula_cli);
            ViewBag.id_rol = new SelectList(db.rol, "id_rol", "rol1", usuario.id_rol);
            ViewBag.codigo_tra = new SelectList(db.trabajador, "codigo", "nombre", usuario.codigo_tra);
            return View(usuario);
        }

        // GET: usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.cedula_cli = new SelectList(db.cliente, "cedula", "nombre", usuario.cedula_cli);
            ViewBag.id_rol = new SelectList(db.rol, "id_rol", "rol1", usuario.id_rol);
            ViewBag.codigo_tra = new SelectList(db.trabajador, "codigo", "nombre", usuario.codigo_tra);
            return View(usuario);
        }

        // POST: usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_usuario,nombre_usuario,id_rol,codigo_tra,cedula_cli")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cedula_cli = new SelectList(db.cliente, "cedula", "nombre", usuario.cedula_cli);
            ViewBag.id_rol = new SelectList(db.rol, "id_rol", "rol1", usuario.id_rol);
            ViewBag.codigo_tra = new SelectList(db.trabajador, "codigo", "nombre", usuario.codigo_tra);
            return View(usuario);
        }

        // GET: usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usuario usuario = db.usuario.Find(id);
            db.usuario.Remove(usuario);
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
