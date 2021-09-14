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
using YNHM.RepositoryServices;
using YNHM.WebApp.Models;

namespace YNHM.WebApp.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        RoomieRepository pr = new RoomieRepository();
        ApplicationDbContext db = new ApplicationDbContext();

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ManageController()
        {
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
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

        //TODO: FIX view model
        //
        //GET: /Manage/ViewProfile
        public ActionResult ViewProfile()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var roomie = pr.GetById(user.RoomieId);

            PersonDetailsVM vm = new PersonDetailsVM(roomie);

            return RedirectToAction($"PersonalProfile/{user.RoomieId}", "HomePage");
            //return View(vm);
        }

        //GET: /Manage/EditUserDetails
        public async Task<ActionResult> EditUserDetails()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var roomie = pr.GetById(user.RoomieId);

            roomie.PhotoUrl = user.UserPhoto;

            PersonDetailsVM vm = new PersonDetailsVM(roomie);
            return View(vm);
        }

        //POST: /Manage/EditUserDetails
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserDetails([Bind(Include = "Id,FirstName,LastName,Age,Email,Phone,Facebook,HasHouse, PhotoUrl")] Roomie roomie)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var user = UserManager.FindById(User.Identity.GetUserId());

            if (ModelState.IsValid)
            {
                db.Entry(roomie).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                roomie.PhotoUrl = user.UserPhoto;

                return RedirectToAction("Index", "HomePage");
            }
            PersonDetailsVM vm = new PersonDetailsVM(roomie);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePhoto(UploadPhotoVM uploadPhotoVM)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("EditUserDetails");
            }

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            if (user == null) { return Redirect("~/Shared/Error"); }

            if (uploadPhotoVM.ImageFile != null)
            {
                uploadPhotoVM.ImageFile.SaveAs(Server.MapPath("~/Content/images/user/" + user.Id + ".jpg"));

                uploadPhotoVM.Image = "~/Content/images/user/" + user.Id + ".jpg";
            }
            else
            {
                return Redirect("~/Shared/Error");
            }
            user.UserPhoto = "/Content/images/user/" + user.Id + ".jpg";

            var result = await UserManager.UpdateAsync(user);
            if (result.Succeeded) { return RedirectToAction("EditUserDetails"); }
            else { return Redirect("~/Shared/Error"); }

        }

        public async Task<ActionResult> CreateRoomie()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            CreateRoomieVM vm = new CreateRoomieVM()
            {
                PhotoUrl = user.UserPhoto
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRoomie(CreateRoomieVM cr)
        {
            var userId = User.Identity.GetUserId();
            var user = UserManager.FindById(userId);

            if (ModelState.IsValid)
            {
                Roomie r = new Roomie()
                {
                    FirstName = cr.FirstName,
                    LastName = cr.LastName,
                    Age = cr.Age,
                    HasHouse = cr.HasHouse,
                    Email = user.Email,
                    Phone = cr.Phone,
                    Facebook = cr.Facebook,
                    PhotoUrl = user.UserPhoto
                };

                if (r.HasHouse)
                {
                    var house = CreateHouse(r);
                    r.House = house;
                }

                db.Roomies.Add(r);
                db.SaveChanges();

                user.RoomieId = r.Id;
                UserManager.Update(user);

                return RedirectToAction("Subscriptions", "HomePage");
            }
            return View(cr);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UploadPhoto(UploadPhotoVM uploadPhotoVM)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("CreateRoomie");
            }

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            if (user == null) { return Redirect("~/Shared/Error"); }

            if (uploadPhotoVM.ImageFile != null)
            {
                uploadPhotoVM.ImageFile.SaveAs(Server.MapPath("~/Content/images/user/" + user.Id + ".jpg"));

                uploadPhotoVM.Image = "~/Content/images/user/" + user.Id + ".jpg";
            }
            else
            {
                return Redirect("~/Shared/Error");
            }
            user.UserPhoto = "/Content/images/user/" + user.Id + ".jpg";

            var result = await UserManager.UpdateAsync(user);
            if (result.Succeeded) { return RedirectToAction("CreateRoomie"); }
            else { return Redirect("~/Shared/Error"); }

        }

        private House CreateHouse(Roomie r)
        {
            Random rand = new Random();
            string[] streets =
{
                    "Ipirou", "Patission","Panepistimiou", "Frynis","Kerkyras",
                    "Pl. Koliatsou","Skiathou","Skopelou","Kykladon","Tritis Septemvriou",
                    "Agiou Nikolaou","Agiou Georgiou","Agias Annas","Agias Zonis","Agias Kiriakis",
                    "Ari Velouchioti","Angelou Sikelianou","Kosma Aitolou","Athinas","Iras",
                    "Afroditis","Dia","Autokratoron Angelon","Themistokleous","Perikleous"
                };

            string[] districts =
            {
                    "Center","Zografou","Exarcheia","Kolonaki","Kato Patissia",
                    "Kypseli","Kaisariani","Perama","Peiraias","Pasalimani",
                    "Nea Smyrni","Kallithea"
                };

            string address = $"{streets[rand.Next(0, streets.Length)]} {rand.Next(1, 350)}";
            string district = $"{districts[rand.Next(0, districts.Length)]}";
            int rooms = rand.Next(2, 6);
            int floor = rand.Next(0, 11);
            int rent = 0;
            int area = 0;

            if (rooms > 2)
            {
                area = rand.Next(70, 200);
            }
            else
            {
                area = rand.Next(45, 200);
            }

            if (area > 100)
            {
                rent = rand.Next(350, 601);
            }
            else
            {
                rent = rand.Next(200, 601);
            }

            House h = new House()
            {
                Address = address,
                District = district,
                Area = area,
                Bedrooms = rooms,
                Floor = floor,
                Rent = rent
            };

            h.Roomies.Add(r);
            db.SaveChanges();
            return h;
        }

        public ActionResult MatchDetails()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var userRoomie = db.Roomies.Find(user.RoomieId);

            var pairs = db.RoomiesPair
                .Where(p => p.RoomieOneId == userRoomie.Id || p.RoomieTwoId == userRoomie.Id)
                .ToList();

            Dictionary<Roomie, int> pairedRoomies = new Dictionary<Roomie, int>();
            foreach (var pair in pairs)
            {
                int id = pair.RoomieOneId != userRoomie.Id ? id = pair.RoomieOneId : id = pair.RoomieTwoId;
                var roomie = db.Roomies.Find(id);
                pairedRoomies.Add(roomie, pair.MatchPercentage);
            }
            var house = userRoomie.House;

            pairedRoomies = pairedRoomies.OrderBy(r => r.Key.LastName).ThenBy(r => r.Key.FirstName).ToDictionary(x => x.Key, x => x.Value);
            MatchDetailsVM vm = new MatchDetailsVM()
            {
                PairedRoomies = pairedRoomies,
                House = house
            };
            return View(vm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";
        #endregion
    }
}