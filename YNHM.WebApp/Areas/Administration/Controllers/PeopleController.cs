using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using YNHM.Database;
using YNHM.Entities.Models;
using YNHM.RepositoryServices;

namespace YNHM.WebApp.Areas.Administration.Controllers
{
    public class PeopleController : Controller
    {
        readonly ApplicationDbContext db = new ApplicationDbContext();
        readonly RoomieRepository pr = new RoomieRepository();

        // GET: People
        public ActionResult Index()
        {
            var roomies = db.Roomies.ToList();

            return View(roomies);
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roomie roomie = db.Roomies.Find(id);
            if (roomie == null)
            {
                return HttpNotFound();
            }
            return View(roomie);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            ViewBag.HouseList = new SelectList(db.Houses, "Id", "Address");
            return View();
        }


        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Age,MatchPercent,Phone,Email,Facebook,Description,PhotoUrl,HouseId")] Roomie roomie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomie).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HouseList = new SelectList(db.Houses, "Id", "Address");
            return View(roomie);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roomie roomie = db.Roomies.Find(id);
            if (roomie == null)
            {
                return HttpNotFound();
            }
            ViewBag.HouseList = new SelectList(db.Houses, "Id", "Address");
            return View(roomie);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Age,MatchPercent,Phone,Email,Facebook,Description,PhotoUrl,HouseId")] Roomie roomie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomie).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
          

            ViewBag.HouseList = new SelectList(db.Houses, "Id", "Address");
            return View(roomie);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roomie roomie = db.Roomies.Find(id);
            if (roomie == null)
            {
                return HttpNotFound();
            }
            return View(roomie);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Roomie roomie = db.Roomies.Find(id);

            db.Entry(roomie).State = EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
