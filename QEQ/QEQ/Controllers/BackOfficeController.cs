using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QEQ.Models; 

namespace QEQ.Controllers
{
    public class BackOfficeController : Controller
    {
        // GET: BackOffice
        public ActionResult ABMCaracteristica()
        {
            ViewBag.ListaCaracteristicas = Conexion.ListarCaracteristica();
            return View();
        }

        [HttpPost]
        public ActionResult EdicionCaracteristica(string Accion, int ID = 0)
        {
            ViewBag.Enabled = new { };
            ViewBag.Accion = Accion;
            if (Accion == "Insertar")
            {
                return View("FormCaracteristica");
            }
            if ((Accion == "Editar") || (Accion == "Eliminar") || (Accion == "Ver"))
            {
                if ((Accion == "Ver") || (Accion == "Eliminar"))
                    ViewBag.Enabled = new { disabled = "disabled" };
                Caracteristica x = Conexion.ObtenerCaracteristica(ID);
                return View("FormCaracteristica", x);
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult GrabarCaracteristica(Caracteristica x, string Accion)
        {
            ViewBag.Accion = Accion;
            if (!ModelState.IsValid)
            {
                return View("FormCaracteristica", x);
            }
            else
            {
                switch (Accion)
                {
                    case "Insertar":
                        Conexion.InsertarCaracteristica(x);
                        break;
                    case "Editar":
                        Conexion.ModificarCaracteristica(x);
                        break;
                    case "Eliminar":
                        Conexion.EliminarCaracteristica(x.ID);
                        break;
                }
                return View("FormCaracteristica", x);
            }
        }
    }
}
