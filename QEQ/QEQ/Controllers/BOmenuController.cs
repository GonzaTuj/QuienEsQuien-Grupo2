using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class BOmenuController : Controller
    {
        // GET: BOmenu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ABMCarac()
        {
            return ABMCarac();
        }
        public ActionResult ABMCateg()
        {
            return ABMCateg();
        }
        public ActionResult ABMPers()
        {
            return ABMPers();
        }

    }
}