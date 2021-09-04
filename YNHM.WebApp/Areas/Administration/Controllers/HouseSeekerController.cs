using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YNHM.Database;
using YNHM.Entities.Models;

namespace YNHM.WebApp.Areas.Administration.Controllers
{
    public class HouseSeekerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administration/HouseSeeker
        public ActionResult Index()
        {
            var houseSeekers = db.HouseSeekers.Include(h => h.House).Include(h => h.Test);
            return View(houseSeekers.ToList());
        }

        // GET: Administration/HouseSeeker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseSeeker houseSeeker = db.HouseSeekers.Find(id);
            if (houseSeeker == null)
            {
                return HttpNotFound();
            }
            return View(houseSeeker);
        }

        // GET: Administration/HouseSeeker/Create
        public ActionResult Create()
        {
            ViewBag.HouseSeekerId = new SelectList(db.Houses, "HouseSeekerId", "Title");
            ViewBag.HouseSeekerId = new SelectList(db.Tests, "HouseSeekerId", "Name");
            return View();
        }

        // POST: Administration/HouseSeeker/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HouseSeekerId,MatchPercent,TestId,FirstName,LastName,Age,Phone,Email,Facebook,Description,PhotoUrl")] HouseSeeker houseSeeker)
        {
            if (ModelState.IsValid)
            {
                db.HouseSeekers.Add(houseSeeker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HouseSeekerId = new SelectList(db.Houses, "HouseSeekerId", "Title", houseSeeker.HouseSeekerId);
            ViewBag.HouseSeekerId = new SelectList(db.Tests, "HouseSeekerId", "Name", houseSeeker.HouseSeekerId);
            return View(houseSeeker);
        }

        // GET: Administration/HouseSeeker/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseSeeker houseSeeker = db.HouseSeekers.Find(id);
            if (houseSeeker == null)
            {
                return HttpNotFound();
            }
            ViewBag.HouseSeekerId = new SelectList(db.Houses, "HouseSeekerId", "Title", houseSeeker.HouseSeekerId);
            ViewBag.HouseSeekerId = new SelectList(db.Tests, "HouseSeekerId", "Name", houseSeeker.HouseSeekerId);
            return View(houseSeeker);
        }

        // POST: Administration/HouseSeeker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HouseSeekerId,MatchPercent,TestId,FirstName,LastName,Age,Phone,Email,Facebook,Description,PhotoUrl")] HouseSeeker houseSeeker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(houseSeeker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HouseSeekerId = new SelectList(db.Houses, "HouseSeekerId", "Title", houseSeeker.HouseSeekerId);
            ViewBag.HouseSeekerId = new SelectList(db.Tests, "HouseSeekerId", "Name", houseSeeker.HouseSeekerId);
            return View(houseSeeker);
        }

        // GET: Administration/HouseSeeker/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseSeeker houseSeeker = db.HouseSeekers.Find(id);
            if (houseSeeker == null)
            {
                return HttpNotFound();
            }
            return View(houseSeeker);
        }

        // POST: Administration/HouseSeeker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HouseSeeker houseSeeker = db.HouseSeekers.Find(id);
            db.HouseSeekers.Remove(houseSeeker);
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
