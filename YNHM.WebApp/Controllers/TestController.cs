using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
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
        public ActionResult Index()
        {
            return View();
        }

        //GET: TakeTest
        public ActionResult TakeTest()
        {
            var seeker = GetSeeker();
            Test test = seeker.Test;
            TakeTestVM takeTestVM = new TakeTestVM(test);

            return View(takeTestVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TakeTest(TakeTestVM takeTestVM)
        {
            return View(takeTestVM);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewTest()
        {
            var seeker = GetSeeker();
            
            if (seeker.Test != null)
            {
                return RedirectToAction("TakeTest", "Test");
            }

            QuestionSet questionSet = db.QuestionSets.Find(1);
            Test test = new Test(questionSet);
            test.PersonId = seeker.HouseSeekerId;
            seeker.Test = test;

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Test");
            }

            db.Tests.Add(test);
            db.SaveChanges();

            return RedirectToAction("TakeTest", "Test");
        }

        //Helpers
        //TODO: VASSILIS: Move to Repo
        private HouseSeeker GetSeeker()
        {
            var userId = User.Identity.GetUserId();
            var user = UserManager.FindById(userId);
            return db.HouseSeekers.Find(user.HouseSeekerId);
        }

    }
}