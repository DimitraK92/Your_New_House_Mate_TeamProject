using System;
using System.Collections.Generic;
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
        HousesController hc = new HousesController();

        // GET: People
        public ActionResult Index(string searchText, string selectOption)
        {
            var roomies = db.Roomies.OrderByDescending(x=>x.HouseId).ToList();

            #region Filtering

            if (!String.IsNullOrEmpty(searchText))
            {
                switch (selectOption)
                {
                    case "First Name": roomies = roomies.Where(x => x.FirstName.ToUpper().Contains(searchText.ToUpper())).ToList(); break;
                    case "Last Name": roomies = roomies.Where(x => x.LastName.ToUpper().Contains(searchText.ToUpper())).ToList(); break;
                    case "Email": roomies = roomies.Where(x => x.Email.ToUpper().Contains(searchText.ToUpper())).ToList(); break;
                    case "Phone Number": roomies = roomies.Where(x => x.Phone.ToUpper().Contains(searchText.ToUpper())).ToList(); break;
                    case "Min Age": roomies = roomies.Where(x => x.Age >= Convert.ToInt32(searchText)).ToList(); break;
                    case "Max Age": roomies = roomies.Where(x => x.Age <= Convert.ToInt32(searchText)).ToList(); break;
                    case "House": roomies = roomies.Where(x => x.HasHouse == Boolean.Parse(searchText)).ToList(); break;                   
                }
            }

            #endregion


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

                if (roomie.HouseId != null)
                {
                    var house = db.Houses.Find(roomie.HouseId);
                    roomie.House = house;
                    roomie.HasHouse = true;

                    db.Houses.Attach(house);
                    db.Entry(house).Collection("Roomies").Load();
                    house.Roomies.Add(roomie);
                    db.Entry(house).State = EntityState.Modified;

                    if (roomie.House.Roomies.Count > 1)
                    {
                        try
                        {
                            var houseRoomies = house.Roomies.ToList();
                            var tempRoomies = new List<Roomie>();
                            var tempRoomiesTwo = new List<Roomie>();

                            for (int i = 0; i < houseRoomies.Count; i++)
                            {
                                tempRoomies.Add(houseRoomies[i]);

                                for (int j = 0; j < houseRoomies.Count; j++)
                                {
                                    if (!tempRoomies.Contains(houseRoomies[j]))
                                    {
                                        tempRoomiesTwo.Add(houseRoomies[j]);

                                        RoomiesPair newPairFirstVersion = new RoomiesPair()
                                        {
                                            RoomieOneId = houseRoomies[i].Id,
                                            RoomieTwoId = houseRoomies[j].Id
                                        };

                                        RoomiesPair newPairSecondVersion = new RoomiesPair()
                                        {
                                            RoomieOneId = houseRoomies[j].Id,
                                            RoomieTwoId = houseRoomies[i].Id

                                        };
                                        var existingPairs = db.RoomiesPair.ToList();

                                        if (!(existingPairs.Contains(newPairFirstVersion) || existingPairs.Contains(newPairSecondVersion)))
                                        {
                                            hc.GenerateMatch(houseRoomies[i], houseRoomies[j]);
                                            houseRoomies[i].IsMatched = true;
                                            houseRoomies[j].IsMatched = true;
                                        }

                                    }

                                }

                            }
                        }
                        catch (System.Exception)
                        {

                            return RedirectToAction("Index");
                        }

                        db.Entry(roomie).State = EntityState.Modified;
                    }
                    db.Entry(roomie).State = EntityState.Modified;
                    db.SaveChanges();
                }

               

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

            if (roomie.Test != null)
            {
                var roomieTest = db.Tests.Find(roomie.Test.TestId);
                db.Tests.Attach(roomieTest);
                db.Entry(roomieTest).Collection("Questions").Load();
                roomieTest.Questions.Clear();
                db.Tests.Remove(roomieTest);
            }
            

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
