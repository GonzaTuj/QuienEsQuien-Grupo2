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
    }
}