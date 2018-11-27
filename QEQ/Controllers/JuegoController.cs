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
            Lista = Conexion.ListarPersonaje();
            foreach (Personaje p in Lista)
            {

            }
            return Lista;
        }
    }
}

    
