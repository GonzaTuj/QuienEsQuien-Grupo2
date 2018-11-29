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

        public ActionResult Juego()
        {
            //ELEGIR PREGUNTA SEGÚN CATEGORIAS QUE ELIGIÓ ANTES 
            return View();
        }

        public ActionResult SeleccionarCategoria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerificarModo(string Modo, int ID)
        {
            //SESSION
            Usuario user = Session["Usuario"] as Usuario;
            string nom = "", pass = "";
            int monedas = 0;
            if (user == null)
            {
                nom = "Invitado";
                pass = "Invitado";
                monedas = 1000000;
            }
            Usuario Jugador = new Usuario(nom, pass, monedas);
            if (Modo == "Individual")
            {
                //SELECCIONAR PERSONAJE
                ListaPersonajes = Conexion.ListarPersonaje(ID);
                Random rnd = new Random();
                int r = rnd.Next(ListaPersonajes.Count);
                Personaje PersonajeElegido = ListaPersonajes[r];
                return View("Juego"); 
            }
            else if (Modo == "Multijugador")
            {
                //SESSION
                Usuario Jugador2 = new Usuario("Jugador 2", "Jugador2", 1000000);
                return View("SeleccionarPersonaje", ID); 
            }
            return View("SeleccionarCategoria"); 
        }

        [HttpPost]
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
    }   
}

    
