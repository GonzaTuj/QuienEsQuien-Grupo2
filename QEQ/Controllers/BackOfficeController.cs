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
            var user = Session["Usuario"] as Usuario;
            if (user.EsAdmin)
            {
                ViewBag.ListaCaracteristicas = Conexion.ListarCaracteristica();
                return View();
            }
            else return RedirectToAction("Index", "Home");
        }
        public ActionResult FormCaracteristica()
        {
            var user = Session["Usuario"] as Usuario;
            if (user.EsAdmin)
                return View();
            else return RedirectToAction("Index", "Home");
        }
        public ActionResult FormPersonaje()
        {
            var user = Session["Usuario"] as Usuario;
            if (user.EsAdmin)
                return View();
            else return RedirectToAction("Index", "Home");
        }
        public ActionResult FormCategoriaC()
        {
            var user = Session["Usuario"] as Usuario;
            if (user.EsAdmin)
                return View();
            else return RedirectToAction("Index", "Home");
        }
        public ActionResult FormCategoriaP()
        {
            var user = Session["Usuario"] as Usuario;
            if (user.EsAdmin)
                return View();
            else return RedirectToAction("Index", "Home");
        }

        public ActionResult ABMCategoriaC()
        {
            var user = Session["Usuario"] as Usuario;
            if (user.EsAdmin)
            {
                ViewBag.ListaCategoriasC = Conexion.ListarCategoriaC();
                return View();
            }
            else return RedirectToAction("Index", "Home");
        }

        public ActionResult ABMCategoriaP()
        {
            var user = Session["Usuario"] as Usuario;
            if (user.EsAdmin)
            {
                ViewBag.ListaCategoriaP = Conexion.ListarCategoriaP();
                return View();
            }
            else return RedirectToAction("Index", "Home");
        }

        public ActionResult ABMPersonaje()
        {
            var user = Session["Usuario"] as Usuario;
            if (user.EsAdmin)
            {
                ViewBag.ListaPersonajes = Conexion.ListarPersonaje();
                return View();
            }
            else return RedirectToAction("Index", "Home");
        }

        public ActionResult HomeAdmin()
        {
            var user = Session["Usuario"] as Usuario;
            if (user.EsAdmin)
            return View();
            else return RedirectToAction("Index", "Home");
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
                    return View("FormCaracteristica", x);
                }

                if (Accion == "Editar")
                {
                    Caracteristica x = Conexion.ObtenerCaracteristica(ID);
                    return View("FormCaracteristica", x);
                }

                if (Accion == "Eliminar")
                {
                    Conexion.EliminarCaracteristica(ID);
                }
            }
            return RedirectToAction("ABMCaracteristica");
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
                    CategoriaCaracteristica x = Conexion.ObtenerCategoriaC(ID);
                    return View("FormCategoriaC", x);
                }

                if (Accion == "Eliminar")
                {
                  Conexion.EliminarCategoriaC(ID);
                }

                return RedirectToAction("ABMCategoriaC");
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
                return RedirectToAction("ABMCategoriaC");
            }
        }

      
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
                if (Accion == "Ver") 
                    ViewBag.Enabled = new { disabled = "disabled" };
                CategoriaPersonaje cp = Conexion.ObtenerCategoriaP(ID);

                if (Accion == "Eliminar")
                {
                    Conexion.EliminarCategoriaP(ID);
                }
                if (Accion == "Editar")
                {
                    CategoriaPersonaje x = Conexion.ObtenerCategoriaP(ID);
                    return View("FormCategoriaP", x);
                }
                return RedirectToAction("ABMCategoriaP");
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
                return RedirectToAction("ABMCategoriaP", x);
            }
        }

<<<<<<< HEAD
=======

>>>>>>> bbc79c167b7927afcf9f4a37af9a37b4a7ee5329
        public ActionResult EdicionPersonaje(string Accion, int ID = 0)
        {
            ViewBag.Enabled = new { };
            ViewBag.Accion = Accion;

            if (Accion == "Insertar")
            {
                Personaje p = new Personaje();
                return View("FormPersonaje", p);
            }
            if ((Accion == "Editar") || (Accion == "Eliminar") || (Accion == "Ver"))
            {
<<<<<<< HEAD
                if (Accion == "Insertar")
=======
                if (Accion == "Ver")
                {
                    ViewBag.Enabled = new { disabled = "disabled" };
                    Personaje x = Conexion.ObtenerPersonaje(ID);
                }
                if (Accion == "Eliminar")
>>>>>>> bbc79c167b7927afcf9f4a37af9a37b4a7ee5329
                {
                    return View("FormPersonaje");
                }
                if ((Accion == "Editar") || (Accion == "Eliminar") || (Accion == "Ver"))
                {
<<<<<<< HEAD
                    if (Accion == "Ver")
                    {
                        ViewBag.Enabled = new { disabled = "disabled" };
                        Personaje p = Conexion.ObtenerPersonaje(ID);
                        return View("FormPersonaje", p);
                    }
                    if (Accion == "Eliminar")
                    {
                        Conexion.EliminarPersonaje(ID);
                    }
                    if (Accion == "Editar")
                    {

                        Personaje x = Conexion.ObtenerPersonaje(ID);
                        return View("FormPersonaje", x);

                    }
                    return RedirectToAction("ABMPersonaje");
=======
                    Personaje x = Conexion.ObtenerPersonaje(ID);
                    return View("FormPersonaje", x);

>>>>>>> bbc79c167b7927afcf9f4a37af9a37b4a7ee5329
                }
                
            }
            return View("Index");
        }

<<<<<<< HEAD
=======


        

>>>>>>> bbc79c167b7927afcf9f4a37af9a37b4a7ee5329
        [HttpPost]
        public ActionResult GrabarPersonaje(Personaje x, string Accion)
        {
            ViewBag.Accion = Accion;
            if (!ModelState.IsValid)
            {
                ViewBag.Accion = Accion;
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
                return RedirectToAction("ABMPersonaje", x);
            }
        }
    }
}
