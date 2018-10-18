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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerificarLogin(Usuario x)
        {
            if (ModelState.IsValid)
            {
                Usuario NuevoUsuario = new Usuario();
                NuevoUsuario = Conexion.ObtenerUsuario(x.NombreUsuario, x.Password, "InicioSesion");
                if  ((NuevoUsuario.NombreUsuario != "") && (NuevoUsuario.Password != ""))
                {
                    if (NuevoUsuario.EsAdmin == true)
                        return View("HomeAdmin");
                    else
                        return View("Home");
                }
                else
                {
                    ViewBag.Advertencia = "Usuario invalido. El Nombre o la Contraseña es incorrecto.";
                }
            }
            return View("Login");
        }
    
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerificarRegistro(Usuario x)
        {
            if (ModelState.IsValid)
            {
                Usuario NuevoUsuario = new Usuario();
                NuevoUsuario = Conexion.ObtenerUsuario(x.NombreUsuario, x.Password, "Registro");
                if ((NuevoUsuario.NombreUsuario != "") && (NuevoUsuario.Password != ""))
                {
                    ViewBag.Advertencia = "Usuario ya registrado.";
                    return View("Registro");
                }
                else if (Conexion.InsertarUsuario(x) != 0)
                {
                   ViewBag.Advertencia = "Usuario registrado con exito.";
                   return View("Registro");
                }      
            }
            return View("Registro");
        }
    }
}