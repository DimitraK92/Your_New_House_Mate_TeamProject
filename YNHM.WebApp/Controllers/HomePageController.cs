using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YNHM.Database;
using YNHM.Entities.Models;
using YNHM.Entities.TestResources;
using YNHM.RepositoryServices;
using YNHM.WebApp.Models;

namespace YNHM.WebApp.Controllers
{

    //TODO: VASSILIS Fix active tab on the navbar
    [Authorize]
    public class HomePageController : Controller
    {
        #region UserManager
        private ApplicationUserManager _userManager;

        public HomePageController()
        {
        }

        public HomePageController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        #endregion

        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();
        private readonly RoomieRepository hsr = new RoomieRepository();

        // GET: HomePage
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }

        public ActionResult People(string searchText, string selectOption)
        {
            Roomie currentRoomie = GetCurrentRoomie();

            if (currentRoomie.HasTest == false)
            {
                ViewBag.Message = "You have not yet taken the test. You have been redirected here instead.";
                return RedirectToAction("TestInfo", "Test");
            }

            List<Roomie> roomies = new List<Roomie>();
            try
            {
                roomies = dbContext.Roomies
                            .Where(r => r.Id != currentRoomie.Id && r.IsMatched == false && r.HasTest).ToList()
                            .Where(r => r.HasHouse != currentRoomie.HasHouse).ToList();

                if (!currentRoomie.HasHouse)
                {
                    var matchedWithRooms = dbContext.Roomies.Where(r => r.Id != currentRoomie.Id && r.IsMatched)
                        .Where(r => r.House.Roomies.Count != r.House.Bedrooms).ToList();
                    roomies.AddRange(matchedWithRooms);
                }
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
            }
            var compared = CompareRoomies(currentRoomie, roomies);

            #region Filtering

            if (!String.IsNullOrEmpty(searchText))
            {
                switch (selectOption)
                {
                    case "First Name": compared = compared.Where(x => x.Key.FirstName.ToUpper().Contains(searchText.ToUpper())).ToDictionary(x => x.Key, x => x.Value); break;
                    case "Percentage": compared = compared.Where(x => x.Value > Convert.ToInt32(searchText)).ToDictionary(x => x.Key, x => x.Value); break;
                }
            }


            #endregion

            PercentageVM vm = new PercentageVM()
            {
                CurrentUser = currentRoomie,
                Roomies = roomies,
                Compared = compared
            };

            return View(vm);
        }

        public ActionResult PersonalProfile(int? id, int? percentage)
        {
            if (id == null || percentage == null)
            {
                return View("Error");
            }
            var roomieId = id.GetValueOrDefault();
            Roomie roomie = null;
            try
            {
                roomie = hsr.GetById(roomieId);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
            }
            if (roomie == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var currentRoomie = GetCurrentRoomie();
            PersonalProfileVM vm = new PersonalProfileVM(currentRoomie, roomie, percentage.GetValueOrDefault());
            return View(vm);
        }

        public ActionResult Match(int matchedUserId)
        {
            Roomie currentRoomie = GetCurrentRoomie();
            Roomie match = dbContext.Roomies.Find(matchedUserId);

            var roomieWithHouse = currentRoomie.HasHouse == true ? currentRoomie : match;
            var roomieWithoutHouse = currentRoomie.HasHouse == false ? currentRoomie : match;

            bool roomsLeft = roomieWithHouse.House.Bedrooms - roomieWithHouse.House.Roomies.Count > 0 ? true : false;
            if (!roomsLeft)
            {
                TempData["message"] = "Sorry, you cannot add this person, your house is full. :(";
                return RedirectToAction("MatchDetails", "Manage");
            }

            Comparison compare = new Comparison();

            match.IsMatched = true;
            currentRoomie.IsMatched = true;

            dbContext.Entry(match).State = EntityState.Modified;
            dbContext.Entry(currentRoomie).State = EntityState.Modified;
            dbContext.SaveChanges();

            RoomiesPair pair = new RoomiesPair();
            pair.RoomieOneId = currentRoomie.Id;
            pair.RoomieTwoId = matchedUserId;
            pair.MatchPercentage = compare.CalculateMatchPercentage(currentRoomie.Test, match.Test);

            dbContext.Entry(pair).State = EntityState.Added;
            dbContext.SaveChanges();

            //Add roomie to House.Roomies & Add house to Roomie.House
            var house = roomieWithHouse.House;
            roomieWithoutHouse.HasHouse = true;
            dbContext.Entry(roomieWithoutHouse).State = EntityState.Modified;

            dbContext.Houses.Attach(house);
            dbContext.Entry(house).Collection("Roomies").Load();
            house.Roomies.Add(roomieWithoutHouse);
            dbContext.Entry(house).State = EntityState.Modified;
            dbContext.SaveChanges();

            TempData["message"] = "Great, you have been matched! Try to have some fun until you die! :D";
            return RedirectToAction("MatchDetails", "Manage");
        }

        public ActionResult House(int? houseId)
        {
            var house = dbContext.Houses.Find(houseId);
            return View(house);
        }

        [AllowAnonymous]
        public ActionResult Subscriptions()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            return View(user);
        }

        //Helpers
        public Dictionary<Roomie, int> CompareRoomies(Roomie current, List<Roomie> others)
        {
            Comparison comp = new Comparison();
            Dictionary<Roomie, int> roomiesPercentages = new Dictionary<Roomie, int>();

            for (int i = 0; i < others.Count; i++)
            {
                int percent = comp.CalculateMatchPercentage(current.Test, others[i].Test);

                //Add to percentage if subscriber
                if (others[i].IsSubscribed)
                {
                    percent += 10;
                }
                roomiesPercentages.Add(others[i], percent);
            }
            return roomiesPercentages.OrderByDescending(r => r.Value).ToDictionary(x => x.Key, x => x.Value);
        }
        private Roomie GetCurrentRoomie()
        {
            string currentUserId = User.Identity.GetUserId();
            Roomie currentRoomie;

            var currentUser = UserManager.FindById(currentUserId);
            int currentRoomieId = currentUser.RoomieId;
            currentRoomie = dbContext.Roomies.Find(currentRoomieId);
            return currentRoomie;
        }

    }
}