﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QEQ.Models;

namespace QEQ.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Juego()
        {
            return View();
        }


        public ActionResult About()
        {
            return View();
        }

        public ActionResult Instrucciones()
        {
            return View();
        }

        public ActionResult Jugar()
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
                if ((NuevoUsuario.NombreUsuario != "") && (NuevoUsuario.Password != ""))
                {
                    Session["Usuario"] = NuevoUsuario;

                    if (NuevoUsuario.EsAdmin == true)
                        return RedirectToAction("HomeAdmin", "BackOffice", NuevoUsuario);
                    else
                        return View("Index");
                }
                else
                {
                    ViewBag.Advertencia = "Usuario invalido. El Nombre o la Contraseña es incorrecto.";
                }
            }
            return View("Login", x);
        }

        public ActionResult VerificarLogout()
        {
            Session["Usuario"] = null;
            return View("Index"); 
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