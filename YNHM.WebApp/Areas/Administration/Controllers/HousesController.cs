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
using YNHM.RepositoryServices;

namespace YNHM.WebApp.Areas.Administration.Controllers
{
    
    public class HousesController : Controller
    {
        readonly ApplicationDbContext db = new ApplicationDbContext();
        readonly HouseRepository hr = new HouseRepository();

        // GET: Houses
        public ActionResult Index()
        {
            var houses = hr.GetAll();
            return View(houses);
        }

        // GET: Houses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = hr.GetById(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // GET: Houses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Houses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HouseId,Title,Address,PostalCode,PageViews,Area,Floor,Bedrooms,Rent,District,MapLocation,ElevatorInBuilding,FreeWiFi,Parking,AirCondition,PetFriendly,OutdoorSeating,WheelchairFriendly,PersonId")] House house)
        {
            if (ModelState.IsValid)
            {
                hr.Create(house,null);
                //db.Houses.Add(house);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(house);
        }

        public void CreateManagerViewBag()
        {
            var managers = db.People.ToList()
                .Select(m => new
                {
                    PersonId = m.PersonId,
                    Fullname = String.Format($"{m.FirstName} {m.LastName}")
                });

            ViewBag.PersonId = new SelectList(managers, "PersonId", "Fullname");

        }

        // GET: Houses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = hr.GetById(id);
            if (house == null)
            {
                return HttpNotFound();
            }

            CreateManagerViewBag();

            return View(house);
        }

        // POST: Houses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HouseId,Title,Address,PostalCode,PageViews,Area,Floor,Bedrooms,Rent,District,MapLocation,ElevatorInBuilding,FreeWiFi,Parking,AirCondition,PetFriendly,OutdoorSeating,WheelchairFriendly,PersonId")] House house)
        {
            if (ModelState.IsValid)
            {
                hr.Edit(house, null);
                //db.Entry(house).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            CreateManagerViewBag();
            return View(house);
        }

        // GET: Houses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = hr.GetById(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // POST: Houses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hr.Delete(id);
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
