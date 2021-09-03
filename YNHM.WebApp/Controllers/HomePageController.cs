using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using YNHM.Database;
using YNHM.Entities.Models;
using YNHM.RepositoryServices;

namespace YNHM.WebApp.Controllers
{

    //TODO: VASSILIS Fix active tab on the navbar
    public class HomePageController : Controller
    {
        //private readonly MockupDb mockupDbContext = new MockupDb();
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();
        private readonly HouseRepository hr = new HouseRepository();
        private readonly HouseSeekerRepository hsr = new HouseSeekerRepository();

        // GET: HomePage
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin, HouseSeeker")]
        public ActionResult People()
        {
            List<HouseSeeker> people = new List<HouseSeeker>();
            try
            {
                people = dbContext.HouseSeekers
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

        [Authorize]
        public ActionResult PersonalProfile(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var personId = id.GetValueOrDefault();
            Person person = null;
            try
            {
                person = hsr.GetById(personId);
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

        [Authorize]
        public ActionResult Houses()
        {
            try
            {
                var houses = dbContext.Houses
                    .OrderBy(x => x.Rent)
                    .ThenBy(x => x.Area)
                    .ThenBy(x => x.Bedrooms)
                    .ToList();
                return View(houses);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
        [Authorize]
        public ActionResult SingleListing(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var houseId = id.GetValueOrDefault();
            House house = null;
            
            try
            {
                house = hr.GetById(houseId);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
            }
            if (house == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            house.PageViews++;
            dbContext.SaveChanges();
            return View(house);
        }
    }
}