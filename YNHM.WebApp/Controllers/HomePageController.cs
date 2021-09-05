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
using YNHM.RepositoryServices;
using YNHM.WebApp.Models;

namespace YNHM.WebApp.Controllers
{

    //TODO: VASSILIS Fix active tab on the navbar
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
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin, HouseSeeker")]
        public ActionResult People()
        {
            Roomie currentRoomie = GetCurrentRoomie();

            List<Roomie> roomies = new List<Roomie>();
            try
            {
                roomies = dbContext.Roomies
                            .Where(r => r.Id != currentRoomie.Id && r.IsMatched == false).ToList()
                            .Where(r => r.HasHouse != currentRoomie.HasHouse).ToList();
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
            }

            PercentageVM vm = new PercentageVM()
            {
                CurrentUser = currentRoomie,
                Roomies = roomies
            };

            return View(vm);
        }

        [Authorize]
        public ActionResult PersonalProfile(int? id)
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

            return View(roomie);
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


            //--------------BUGS!!!!!!!!!!!--------------
            //1 ) Houses not passed to roomies, all of them appear to be null
            //I changed the property House in Roomie entity to an initialized House field 
            //in order to avoid the null exception and I implemented some crap down here as well
            //with an if statement for the same reason

            //2) Current User is not correct - it always takes as current user, the roomie with Id = 1



            //Add roomie to House.Roomies & Add house to Roomie.House

            var roomieWithHouse = currentRoomie.HasHouse == true ? currentRoomie : match;
            var roomieWithoutHouse = currentRoomie.HasHouse == false ? currentRoomie : match;


            if (roomieWithHouse.House == null)
            {
                roomieWithHouse.House = new House();
                roomieWithHouse.House = dbContext.Houses.Find(1);
                dbContext.Entry(roomieWithHouse).State = EntityState.Modified;
                dbContext.SaveChanges();

                roomieWithoutHouse.House = new House();
                roomieWithoutHouse.House = roomieWithHouse.House;
                dbContext.Entry(roomieWithoutHouse).State = EntityState.Modified;
                dbContext.SaveChanges();

                var existingHouse = dbContext.Houses.Find(roomieWithHouse.House.Id);
                dbContext.Houses.Attach(existingHouse);
                dbContext.Entry(existingHouse).Collection("Roomies").Load();
                existingHouse.Roomies.Add(roomieWithHouse);
                existingHouse.Roomies.Add(roomieWithoutHouse);
                dbContext.Entry(existingHouse).State = EntityState.Modified;
                dbContext.SaveChanges();

            }

            return Content("Great, you have been matched. Have fun, if you can, until you die.");
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