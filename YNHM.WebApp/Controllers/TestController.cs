using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YNHM.Database;
using YNHM.Entities.Models;
using YNHM.Entities.TestResources;
using YNHM.WebApp.Models;

namespace YNHM.WebApp.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        private ApplicationUserManager userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                userManager = value;
            }
        }

        public TestController()
        {

        }
        public TestController(ApplicationUserManager applicationUserManager)
        {
            UserManager = applicationUserManager;
        }



        // GET: Test
        public ActionResult TestInfo()
        {
            var roomie = GetRoomie();
            return View(roomie);
        }

        //GET: TakeTest
        public ActionResult TakeTest()
        {
            var roomie = GetRoomie();
            Test test = roomie.Test;

            if (roomie.Test==null)
            {
                RedirectToAction("NewTest", "Test");
            }

            ViewBag.Answers = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Yes"},
                new SelectListItem { Text = "Maybe"},
                new SelectListItem { Text = "No"}
            };

            List<Question> Questions = new List<Question>()
            {
                //Housework
                new Question() { Text = "Does cleanliness matter in general?" },
                new Question() { Text = "Are you bothered by a sink full with plates?" },
                new Question() { Text = "Do you mind the house being dusty?" },
                new Question() { Text = "Is cleaning the toilet every day important to you?" },

                //Noise
                new Question() { Text = "Does noise matter in general?" },
                new Question() { Text = "Do you listen to music loud?" },
                new Question() { Text = "Do you value quiet in the house" },
                new Question() { Text = "Will you be with playing musical instruments?" },

                //Food
                new Question() { Text = "Is a vegan or vegetarian diet important to you?" },
                new Question() { Text = "Do you cook every day?" },
                new Question() { Text = "Is keeping your own groceries separate important?" },
                new Question() { Text = "Is eating with your housemates important?" },

                //Animals
                new Question() { Text = "Do you like animal companions?" },
                new Question() { Text = "Will you mind caring for the housemate's animal companions, if they are absent?" },

                //Friends
                new Question() { Text = "Doo you mind friends coming over?" },
                new Question() { Text = "Do you mind friends or significant others staying overnight?" },
                new Question() { Text = "Does hanging out with your housemates matter?" },

                //Smoking
                new Question() { Text = "Do you mind others smoking in the house?" },
                new Question() { Text = "Do you mind others smoking weed in the house?" }
            };
            return View(Questions);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TakeTest(List<Question> questions)
        {
            var roomie = GetRoomie();
            var test = roomie.Test;

            if (ModelState.IsValid)
            {
                var testQuestions = test.Questions.ToList();

                for (int i = 0; i < testQuestions.Count; i++)
                {
                    testQuestions[i].Answer = questions[i].Answer;
                }

                roomie.HasTest = true;
                db.Entry(roomie).State = EntityState.Modified;
                db.Entry(test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TestDetails", "Test");
            }
            List<Question> Questions = test.Questions.ToList();

            return View(Questions);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewTest()
        {
            var roomie = GetRoomie();

            if (roomie.Test != null)
            {
                return RedirectToAction("TakeTest", "Test");
            }

            Test test = new Test()
            {
                Roomie = roomie,
                Name = $"{roomie.FirstName} {roomie.LastName}",
                Questions =new List<Question>()
                {
                    //Housework
                    new Question() { Text = "Does cleanliness matter in general?" },
                    new Question() { Text = "Are you bothered by a sink full with plates?" },
                    new Question() { Text = "Do you mind the house being dusty?" },
                    new Question() { Text = "Is cleaning the toilet every day important to you?" },

                    //Noise
                    new Question() { Text = "Does noise matter in general?" },
                    new Question() { Text = "Do you listen to music loud?" },
                    new Question() { Text = "Do you value quiet in the house" },
                    new Question() { Text = "Will you be with playing musical instruments?" },

                    //Food
                    new Question() { Text = "Is a vegan or vegetarian diet important to you?" },
                    new Question() { Text = "Do you cook every day?" },
                    new Question() { Text = "Is keeping your own groceries separate important?" },
                    new Question() { Text = "Is eating with your housemates important?" },

                    //Animals
                    new Question() { Text = "Do you like animal companions?" },
                    new Question() { Text = "Will you mind caring for the housemate's animal companions, if they are absent?" },

                    //Friends
                    new Question() { Text = "Do you mind friends coming over?" },
                    new Question() { Text = "Do you mind friends or significant others staying overnight?" },
                    new Question() { Text = "Does hanging out with your housemates matter?" },

                    //Smoking
                    new Question() { Text = "Do you mind others smoking in the house?" },
                    new Question() { Text = "Do you mind others smoking weed in the house?" }
                }
            };


            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Test");
            }

            roomie.Test = test;
            db.Entry(roomie).State = EntityState.Modified;
            db.Tests.Add(test);
            db.SaveChanges();
            return RedirectToAction("TakeTest", "Test");
        }


        public ActionResult TestDetails()
        {
            var roomie = GetRoomie();
            var test = roomie.Test;
            return View(test);
        }


        //Helpers
        //TODO: VASSILIS: Move to Repo
        private Roomie GetRoomie()
        {
            var userId = User.Identity.GetUserId();
            var user = UserManager.FindById(userId);
            return db.Roomies.Find(user.RoomieId);
        }

    }
}