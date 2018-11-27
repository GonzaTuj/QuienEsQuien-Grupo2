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
        public ActionResult AgregarJugador()
        {
            return View();
        }
        public ActionResult SleccionarCategoria()
        {
            return View();
        }

        public ActionResult Juego(int ID)
        {
            ViewBag.Seleccionados = Conexion.ObtenerCategoriaP(ID);
            return View();
        }


        public ActionResult SeleccionarCategoria()
        {
            ViewBag.ListaCategoriaP = Conexion.ListarCategoriaP();
            return View();
        }

        [HttpPost]

        public List<Personaje> VerificarCategoria(int ID) //Devuelve lista con Personajes
        {
            List<Personaje> Lista = new List<Personaje>();
            Lista = Conexion.ListarPersonaje(ID);
       
            return Lista;
        }

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

    }



    
}

    
