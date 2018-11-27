using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QEQ.Models;

namespace QEQ.Controllers
{
    public class JuegoController : Controller
    {
        // GET: Juego
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Juego()
        {
            string nom = "invitado";
            string pass = "invitado";
            int monedas = 1000000;
            Usuario user = Session["Usuario"] as Usuario;
            if (user == null)
            {
                Usuario NuevoUsuario = new Usuario(nom, pass, monedas);
                NuevoUsuario = Conexion.InsertarUsuario(user.NombreUsuario, user.Password, user.Monedas);
            }
            return View();
        }


        //(public ActionResult GrabarJugador()
       // {
        //}





    }
}