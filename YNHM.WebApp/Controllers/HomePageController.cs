using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YNHM.Database;
using YNHM.Database.Models;

namespace YNHM.WebApp.Controllers
{

    //TODO: Fix active tab on the navbar
    public class HomePageController : Controller
    {
        //private readonly MockupDb mockupDbContext = new MockupDb();
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();


        // GET: HomePage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult People()
        {
            List<Person> people = new List<Person>();
            try
            {
                people = dbContext.People
                    .OrderByDescending(x => x.MatchPercent)
                    .ThenBy(x => x.Age)
                    .ToList();
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
            }
            return View(people);
        }

        public ActionResult PersonalProfile(Guid? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var personId = id.GetValueOrDefault();
            Person person = null;
            try
            {
                person = dbContext.People.FirstOrDefault(x=>x.Id==personId);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
            }
            if (person == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(person);
        }

        public ActionResult Houses()
        {
            return View("Houses");
        }
    }
}