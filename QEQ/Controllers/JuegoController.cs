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
=======
        public ActionResult AgregarJugador()
        {
            return View();
        }
        public ActionResult SleccionarCategoria()
>>>>>>> b699217a0c14ffbcfdad2101e6c284b6046c4df3
        {
            return View();
        }

<<<<<<< HEAD
=======
        public ActionResult Juego(int ID)
        {
            ViewBag.Seleccionados = Conexion.ObtenerCategoriaP(ID);
            return View();
        }


>>>>>>> b699217a0c14ffbcfdad2101e6c284b6046c4df3
        public ActionResult SeleccionarCategoria()
        {
            ViewBag.ListaCategoriaP = Conexion.ListarCategoriaP();
            return View();
        }

        [HttpPost]
<<<<<<< HEAD

        public List<Personaje> VerificarCategoria(int ID) //Devuelve lista con Personajes
        {
            List<Personaje> Lista = new List<Personaje>();
            Lista = Conexion.ListarPersonaje(ID);
       
            return Lista;
        }

=======
>>>>>>> 04f19f74d08dd846a869baddb0dea2f933dd0614
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
<<<<<<< HEAD

        public ActionResult SeleccionarPersonaje(int ID)
        {
            ListaPersonajes = Conexion.ListarPersonaje(ID);
            ViewBag.ListaPersonajes = ListaPersonajes; 
            return View();
        }

<<<<<<< HEAD
        [HttpPost]
=======
=======

        public ActionResult SeleccionarPersonaje(int ID)
        {
            ListaPersonajes = Conexion.ListarPersonaje(ID);
            ViewBag.ListaPersonajes = ListaPersonajes; 
            return View();
        }

>>>>>>> 04f19f74d08dd846a869baddb0dea2f933dd0614
>>>>>>> b699217a0c14ffbcfdad2101e6c284b6046c4df3
        public ActionResult GrabarPersonajesElegidos(int ID1, int ID2)
        {
            Personaje Personaje1 = Conexion.ObtenerPersonaje(ID1);
            Personaje Personaje2 = Conexion.ObtenerPersonaje(ID2);
            if (Personaje1 != Personaje2)
            {
                return View("Juego");
<<<<<<< HEAD
            }
            else
            {
                return View("SeleccionarPersonaje"); 
            }

           
        }

=======
            }
            else
            {
                return View("SeleccionarPersonaje"); 
            }
        }
<<<<<<< HEAD
=======
<<<<<<< HEAD


=======
>>>>>>> 63db650a85a53d927d45232ae2258b5436070618
>>>>>>> 4191bee4afde3f6259946f91cc608023ff37a0cc
>>>>>>> 04f19f74d08dd846a869baddb0dea2f933dd0614
>>>>>>> b699217a0c14ffbcfdad2101e6c284b6046c4df3
    }



    
}

    
