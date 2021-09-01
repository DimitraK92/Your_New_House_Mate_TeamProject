﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YNHM.WebApp.Controllers
{
    [Authorize(Roles = "Admin, HouseSeeker")]
    public class TestController : Controller
    {

        // GET: Test
        public ActionResult Index()
        {

            return View();
        }
    }
}