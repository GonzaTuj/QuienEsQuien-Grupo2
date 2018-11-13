﻿using System;
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

        public ActionResult ABMCategoriaC()
        {
            ViewBag.ListaCategoriasC = Conexion.ListarCategoriaC();
                return View();
        }

        public ActionResult ABMCategoriaP()
        {
            ViewBag.ListaCategoriaP = Conexion.ListarCategoriaP();
            return View();
        }

        public ActionResult ABMPersonaje()
        {
            ViewBag.ListaPersonajes = Conexion.ListarPersonaje();
            return View();
        }

        public ActionResult HomeAdmin()
        {
            var user = Session["Usuario"] as Usuario;
            if (user.EsAdmin)
            return View();
            else return RedirectToAction("Index", "Home");
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

        [HttpPost]
        public ActionResult EdicionCategoriaC(string Accion, int ID = 0)
        {
            ViewBag.Enabled = new { };
            ViewBag.Accion = Accion;
            if (Accion == "Insertar")
            {
                return View("FormCategoriaC");
            }
            if ((Accion == "Editar") || (Accion == "Eliminar") || (Accion == "Ver"))
            {
                if ((Accion == "Ver") || (Accion == "Eliminar"))
                    ViewBag.Enabled = new { disabled = "disabled" };
                CategoriaCaracteristica x = Conexion.ObtenerCategoriaC(ID);
                return View("FormCategoriaC", x);
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult GrabarCategoriaC(CategoriaCaracteristica x, string Accion)
        {
            ViewBag.Accion = Accion;
            if (!ModelState.IsValid)
            {
                return View("FormCategoriaC", x);
            }
            else
            {
                switch (Accion)
                {
                    case "Insertar":
                        Conexion.InsertarCategoriaC(x);
                        break;
                    case "Editar":
                        Conexion.ModificarCategoriaC(x);
                        break;
                    case "Eliminar":
                        Conexion.EliminarCategoriaC(x.ID);
                        break;
                }
                return View("FormCategoriaC", x);
            }
        }

        [HttpPost]
        public ActionResult EdicionCategoriaP(string Accion, int ID = 0)
        {
            ViewBag.Enabled = new { };
            ViewBag.Accion = Accion;
            if (Accion == "Insertar")
            {
                return View("FormCategoriaP");
            }
            if ((Accion == "Editar") || (Accion == "Eliminar") || (Accion == "Ver"))
            {
                if ((Accion == "Ver") || (Accion == "Eliminar"))
                    ViewBag.Enabled = new { disabled = "disabled" };
                CategoriaPersonaje x = Conexion.ObtenerCategoriaP(ID);
                return View("FormCategoriaP", x);
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult GrabarCategoriaP(CategoriaPersonaje x, string Accion)
        {
            ViewBag.Accion = Accion;
            if (!ModelState.IsValid)
            {
                return View("FormCategoriaP", x);
            }
            else
            {
                switch (Accion)
                {
                    case "Insertar":
                        Conexion.InsertarCategoriaP(x);
                        break;
                    case "Editar":
                        Conexion.ModificarCategoriaP(x);
                        break;
                    case "Eliminar":
                        Conexion.EliminarCategoriaP(x.ID);
                        break;
                }
                return View("FormCategoriaP", x);
            }
        }

        [HttpPost]
        public ActionResult EdicionPersonaje(string Accion, int ID = 0)
        {
            ViewBag.Enabled = new { };
            ViewBag.Accion = Accion;
            if (Accion == "Insertar")
            {
                return View("FormPersonaje");
            }
            if ((Accion == "Editar") || (Accion == "Eliminar") || (Accion == "Ver"))
            {
                if ((Accion == "Ver") || (Accion == "Eliminar"))
                    ViewBag.Enabled = new { disabled = "disabled" };
                Personaje x = Conexion.ObtenerPersonaje(ID);
                return View("FormPersonaje", x);
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult GrabarPersonaje(Personaje x, string Accion)
        {
            ViewBag.Accion = Accion;
            if (!ModelState.IsValid)
            {
                return View("FormPersonaje", x);
            }
            else
            {
                switch (Accion)
                {
                    case "Insertar":
                        Conexion.InsertarPersonaje(x);
                        break;
                    case "Editar":
                        Conexion.ModificarPersonaje(x);
                        break;
                    case "Eliminar":
                        Conexion.EliminarPersonaje(x.IdPers);
                        break;
                }
                return View("FormPersonaje", x);
            }
        }
    }
}
