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
    [Authorize(Roles = "Admin, HouseSeeker")]
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
            return View();
        }

        //GET: TakeTest
        public ActionResult TakeTest()
        {
            var roomie = GetRoomie();
            Test test = roomie.Test;
            AnswerQuestionsVM vm = new AnswerQuestionsVM();

            ViewBag.Answers = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Yes"},
                new SelectListItem { Text = "Maybe"},
                new SelectListItem { Text = "No"}
            };

            ViewBag.TestQuestions = test.Questions.ToList();

            return View(test);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TakeTest([Bind(Include = "TestId,Name")]Test test, IEnumerable<Question> TestQuestions)
        {
            return View(test);
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
                Questions = new List<Question>()
            };

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Test");
            }

            roomie.Test = test;
            db.Entry(roomie).State = EntityState.Modified;
            db.Tests.Add(test);
            return RedirectToAction("TakeTest", "Test");
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