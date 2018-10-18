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
            return View();
        }
        public ActionResult ABMCateg()
        {
            return View();
        }
        public ActionResult ABMPers()
        {
            return View();
        }

    }
}