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
    public class HouseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administration/House
        public ActionResult Index()
        {
            var houses = db.Houses.Include(h => h.HouseSeeker);
            return View(houses.ToList());
        }

        // GET: Administration/House/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // GET: Administration/House/Create
        public ActionResult Create()
        {
            ViewBag.HouseSeekerId = new SelectList(db.HouseSeekers, "HouseSeekerId", "FirstName");
            return View();
        }

        // POST: Administration/House/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HouseSeekerId,HouseId,Title,Address,PostalCode,PageViews,Area,Floor,Bedrooms,Rent,District,MapLocation,ElevatorInBuilding,FreeWiFi,Parking,AirCondition,PetFriendly,OutdoorSeating,WheelchairFriendly")] House house)
        {
            if (ModelState.IsValid)
            {
                //house.HouseSeekerId = house.HouseSeeker.HouseSeekerId;
                db.Houses.Add(house);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
         

            ViewBag.HouseSeekerId = new SelectList(db.HouseSeekers, "HouseSeekerId", "FirstName", house.HouseSeekerId);
            return View(house);
        }

        // GET: Administration/House/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            ViewBag.HouseSeekerId = new SelectList(db.HouseSeekers, "HouseSeekerId", "FirstName", house.HouseSeekerId);
            return View(house);
        }

        // POST: Administration/House/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HouseSeekerId,HouseId,Title,Address,PostalCode,PageViews,Area,Floor,Bedrooms,Rent,District,MapLocation,ElevatorInBuilding,FreeWiFi,Parking,AirCondition,PetFriendly,OutdoorSeating,WheelchairFriendly")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Entry(house).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HouseSeekerId = new SelectList(db.HouseSeekers, "HouseSeekerId", "FirstName", house.HouseSeekerId);
            return View(house);
        }

        // GET: Administration/House/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // POST: Administration/House/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            House house = db.Houses.Find(id);
            db.Houses.Remove(house);
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
