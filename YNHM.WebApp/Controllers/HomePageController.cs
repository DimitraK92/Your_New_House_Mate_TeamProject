using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YNHM.WebApp.Controllers
{
    //TODO: Fix active tab on the navbar
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult People()
        {
            return View("People");
        }

        public ActionResult Houses()
        {
            return View("Houses");
        }
    }
}