using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YNHM.WebApp.Controllers
{

    //TODO: Fix active tab on the left side menu
    public class MyAccountController : Controller
    {
        // GET: MyAccount
        public ActionResult MyAccount()
        {
            return View();
        }

        public ActionResult Password()
        {
            return View("Password");
        }

        public ActionResult Messages()
        {
            return View("Messages");
        }

        public ActionResult Profile()
        {
            return View("Profile");
        }

        public ActionResult EditProfile()
        {
            return View("EditProfile");
        }

        public ActionResult Test()
        {
            return View("Test");
        }
    }
}