using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YNHM.Database;
using YNHM.Database.Mockup;

namespace YNHM.WebApp.Controllers
{

    //TODO: Fix active tab on the navbar
    public class HomePageController : Controller
    {
        private readonly MockupDb mockupDbContext = new MockupDb();
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();


        // GET: HomePage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult People()
        {
            return View(dbContext.People.OrderByDescending(x => x.MatchPercent).ThenBy(x => x.Age).ToList());

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

        public ActionResult Houses(IEnumerable<House>ListOfHouses)
        {
            ListOfHouses = mockupDbContext.MockupHouses.OrderBy(x => x.Rent).ThenBy(x => x.Area).ThenBy(x => x.Bedrooms).ToList();

            return View(ListOfHouses);
        }

        public ActionResult SingleListing(int? houseId)
        {
            var id = houseId;
            if (houseId == null)
            {
                return View("Error");
            }

            var house = mockupDbContext.MockupHouses.Find(h => h.HouseId == houseId);
            return View(house);
        }
    }
}