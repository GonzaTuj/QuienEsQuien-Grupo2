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
        public ActionResult FormCaracteristica()
        {
            return View();
        }
        public ActionResult FormCategoriaC()
        {
            return View();
        }



        public ActionResult ABMCategoriaC()
        {
            ViewBag.ListaCategoriasC = Conexion.ListarCategoriaC();
                return View();
        }

        public ActionResult HomeAdmin()
        {
            var user = Session["Usuario"] as Usuario;
            if (user.EsAdmin)
            return View();
            else return RedirectToAction("Index", "Home");
        }

        public ActionResult ABMPersonajes()
        {
            ViewBag.ListaPersonajes = Conexion.ListarPersonajes();
            return View();
        }


        
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
                if (Accion == "Ver")
                {
                    ViewBag.Enabled = new { disabled = "disabled" };
                    Caracteristica x = Conexion.ObtenerCaracteristica(ID);
                }

                if (Accion == "Editar")
                {
                    Caracteristica c = Conexion.ObtenerCaracteristica(ID);
                    Conexion.ModificarCaracteristica(c);
                    return View("FormCategoriaCmod");
                }

                if (Accion == "Eliminar")
                {
                    Conexion.EliminarCaracteristica(ID);
                }

                return RedirectToAction("ABMCaracteristica");
            }
            return View("Index");
        }

        
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
                return RedirectToAction("ABMCaracteristica");
            }
        }

       
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
                if (Accion == "Ver")
                {
                    ViewBag.Enabled = new { disabled = "disabled" };
                    CategoriaCaracteristica x = Conexion.ObtenerCategoriaC(ID);
                }
                
                if (Accion == "Editar")
                {
                    CategoriaCaracteristica c = Conexion.ObtenerCategoriaC(ID);
                    Conexion.ModificarCategoriaC(c);
                    return View("FormCategoriaCmod");
                }

                if (Accion == "Eliminar")
                {
                  Conexion.EliminarCategoriaC(ID);
                }

                return RedirectToAction("ABMCategoriaC");
            }
            return View("Index");
        }

      
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
                return RedirectToAction("ABMCategoriaC");
            }
        }
    }
}
