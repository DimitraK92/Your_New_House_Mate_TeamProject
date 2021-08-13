using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YNHM.Database.Mockup;

namespace YNHM.WebApp.Controllers
{

    //TODO: Fix active tab on the navbar
    public class HomePageController : Controller
    {
        private readonly MockupDb mockupDbContext = new MockupDb();



        // GET: HomePage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult People(IEnumerable<Person> ListOfPeople)
        {
            ListOfPeople = mockupDbContext.MockupPeople.OrderByDescending(x => x.MatchPercent).ThenBy(x=>x.Age).ToList();

            return View(ListOfPeople);
        }

        public ActionResult PersonalProfile(int? id)
        {
            if (id==null)
            {
                return View("Error");
            }

            var person = mockupDbContext.MockupPeople.Find(x=>x.Id==id);
            return View(person);
        }

        public ActionResult Houses()
        {
            return View("Houses");
        }
    }
}