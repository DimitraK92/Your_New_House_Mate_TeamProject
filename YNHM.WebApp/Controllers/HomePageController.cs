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

        public ActionResult People()
        {
            Roomie currentRoomie = GetCurrentRoomie();

            if (currentRoomie.HasTest==false)
            {
                ViewBag.Message = "You have not yet taken the test. You have been redirected here instead.";
                return RedirectToAction("TestInfo", "Test");
            }

            List<Roomie> roomies = new List<Roomie>();
            try
            {
                roomies = dbContext.Roomies
                            .Where(r => r.Id != currentRoomie.Id && r.IsMatched == false &&r.HasTest).ToList()
                            .Where(r => r.HasHouse != currentRoomie.HasHouse).ToList();
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
            }

            var compared = CompareRoomies(currentRoomie,roomies);

            PercentageVM vm = new PercentageVM()
            {
                CurrentUser = currentRoomie,
                Roomies = roomies,
                Compared = compared
            };

            return View(vm);
        }

        public ActionResult PersonalProfile(int? id, int percentage)
        {
            if (id == null)
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
            PersonalProfileVM vm = new PersonalProfileVM(currentRoomie, roomie, percentage);
            return View(vm);
        }
        
        public ActionResult Match(int matchedUserId)
        {
            Roomie currentRoomie = GetCurrentRoomie();

            Roomie match = dbContext.Roomies.Find(matchedUserId);

            match.IsMatched = true;
            currentRoomie.IsMatched = true;

            dbContext.Entry(match).State = EntityState.Modified;
            dbContext.Entry(currentRoomie).State = EntityState.Modified;
            dbContext.SaveChanges();

            RoomiesPair pair = new RoomiesPair();
            pair.RoomieOneId = currentRoomie.Id;
            pair.RoomieTwoId = matchedUserId;
            pair.MatchPercentage = GetPercentage(currentRoomie, match);

            dbContext.Entry(pair).State = EntityState.Added;
            dbContext.SaveChanges();

            //Add roomie to House.Roomies & Add house to Roomie.House

            var roomieWithHouse = currentRoomie.HasHouse == true ? currentRoomie : match;
            var roomieWithoutHouse = currentRoomie.HasHouse == false ? currentRoomie : match;

            var house = roomieWithHouse.House;
            house.Roomies.Add(roomieWithoutHouse);
            dbContext.Entry(house).State = EntityState.Modified;
            dbContext.SaveChanges();

            return RedirectToAction("Index","HomePage");
        }


        public ActionResult House(int? houseId)
        {
            var house = dbContext.Houses.Find(houseId);
            return View(house);
        }

        public Dictionary<Roomie, int> CompareRoomies(Roomie current, List<Roomie> others)
        {
            Comparison comp = new Comparison();
            Dictionary<Roomie, int> roomiesPercentages = new Dictionary<Roomie, int>();

            for (int i = 0; i < others.Count; i++)
            {
                int percent = comp.CalculateMatchPercentage(current.Test, others[i].Test);
                roomiesPercentages.Add(others[i], percent);
            }
            return roomiesPercentages.OrderByDescending(r=>r.Value).ToDictionary(x=>x.Key,x=>x.Value);
        }


        public int GetPercentage(Roomie current, Roomie compare)
        {
            int percentage = 0;

            bool[] currentAnswer = { current.IsSmoking, current.IsVegan, current.IsNoisy, current.LikesCleaning, current.IsCatPerson };
            bool[] compared = { compare.IsSmoking, compare.IsVegan, compare.IsNoisy, compare.LikesCleaning, compare.IsCatPerson };

            for (int i = 0; i < currentAnswer.Length; i++)
            {
                if (currentAnswer[i] == compared[i])
                {
                    percentage += 20;
                }
            }
            return percentage;
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