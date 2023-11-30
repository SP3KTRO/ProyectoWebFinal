using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWebFinal.Models;

namespace ProyectoWebFinal.Controllers
{
    public class reporteEventoController : Controller
    {
        proyectowebEntities bddatos = new proyectowebEntities();
        // GET: reporteEvento
        public ActionResult vistaEventos()
        {
            return View(bddatos.estadisticas_evento.ToList());
        }
    }
}