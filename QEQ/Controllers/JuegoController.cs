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
        List<Personaje> ListaPersonajes = new List<Personaje>();
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
        public ActionResult VerificarModo(string Modo, int ID)
        { 
            if (Modo == "Individual")
            {
                ListaPersonajes = Conexion.ListarPersonaje(ID);
                Random rnd = new Random();
                int r = rnd.Next(ListaPersonajes.Count);
                Personaje PersonajeElegido = ListaPersonajes[r];
                return View("Juego"); 
            }
            else if (Modo == "Multijugador")
            {
                return View("SeleccionarPersonaje", ID); 
            }
            return View("SeleccionarCategoria"); 
        }

        public ActionResult SeleccionarPersonaje(int ID)
        {
            ListaPersonajes = Conexion.ListarPersonaje(ID);
            ViewBag.ListaPersonajes = ListaPersonajes; 
            return View();
        }

        public ActionResult GrabarPersonajesElegidos(int ID1, int ID2)
        {
            Personaje Personaje1 = Conexion.ObtenerPersonaje(ID1);
            Personaje Personaje2 = Conexion.ObtenerPersonaje(ID2);
            if (Personaje1 != Personaje2)
            {
                return View("Juego");
            }
            else
            {
                return View("SeleccionarPersonaje"); 
            }
        }
<<<<<<< HEAD


=======
>>>>>>> 63db650a85a53d927d45232ae2258b5436070618
>>>>>>> 4191bee4afde3f6259946f91cc608023ff37a0cc
    }
}