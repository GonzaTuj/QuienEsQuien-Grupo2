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
<<<<<<< HEAD
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





=======

        public ActionResult SeleccionarCategoria()
        {
            ViewBag.ListaCategoriaP = Conexion.ListarCategoriaP();
            return View();
        }

        [HttpPost]
        public ActionResult VerificarCategoria(int ID) //Devuelve lista con Personajes
        {
            List<Personaje> Lista = new List<Personaje>();
            Lista = Conexion.ListarPersonaje(); 
            foreach (Personaje p in Lista)
            {

            }
            return Personajes;
        }
>>>>>>> 63db650a85a53d927d45232ae2258b5436070618
    }
}