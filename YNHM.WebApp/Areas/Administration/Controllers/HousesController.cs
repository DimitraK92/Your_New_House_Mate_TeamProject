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
using YNHM.WebApp.Controllers;

namespace YNHM.WebApp.Areas.Administration.Controllers
{
    public class HousesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        HomePageController homePageController = new HomePageController();

        // GET: Administration/Houses
        public ActionResult Index()
        {
            return View(db.Houses.ToList());
        }

        // GET: Administration/Houses/Details/5
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

            var roomiesIds = house.Roomies.Select(x => x.Id).ToList();
            ViewBag.SelectedRoomiesIds = db.Roomies.ToList().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = String.Format($"{x.FirstName} {x.LastName}"),

            });

            return View(house);
        }

        // GET: Administration/Houses/Create
        public ActionResult Create()
        {
            House house = new House();
            
            ViewBag.SelectedRoomiesIds = db.Roomies.ToList().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = String.Format($"{x.FirstName} {x.LastName}"),

            });

            return View(house);
        }

        // POST: Administration/Houses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PhotoUrl,Address,District,Floor,Area,Bedrooms,Rent")] House house, IEnumerable<int> SelectedRoomiesIds)
        {
            if (ModelState.IsValid)
            {
                db.Houses.Attach(house);
                db.Entry(house).Collection("Roomies").Load();
                house.Roomies.Clear();
                db.SaveChanges();

                if (!(SelectedRoomiesIds is null))
                {
                    foreach (var id in SelectedRoomiesIds)
                    {
                        Roomie roomie = db.Roomies.Find(id);
                        if (roomie != null)
                        {
                            house.Roomies.Add(roomie);
                            roomie.HasHouse = true;
                            db.Entry(roomie).State = EntityState.Modified;
                        }
                    }
                    
                }

                db.Entry(house).State = EntityState.Added;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            var roomiesIds = house.Roomies.Select(x => x.Id).ToList();
            ViewBag.SelectedRoomiesIds = db.Roomies.ToList().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = String.Format($"{x.FirstName} {x.LastName}"),
               
            });

            return View(house);
        }

        // GET: Administration/Houses/Edit/5
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
           
            var roomiesIds = house.Roomies.Select(x => x.Id).ToList();
            ViewBag.SelectedRoomiesIds = db.Roomies.ToList().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = String.Format($"{x.FirstName} {x.LastName}"),
                Selected = roomiesIds.Any(y => y == x.Id)
            });

            return View(house);
        }

        // POST: Administration/Houses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PhotoUrl,Address,District,Floor,Area,Bedrooms,Rent")] House house, IEnumerable<int> SelectedRoomiesIds)
        {
            if (ModelState.IsValid)
            {
                db.Houses.Attach(house);
                db.Entry(house).Collection("Roomies").Load();
                house.Roomies.Clear();
                db.SaveChanges();

                if (!(SelectedRoomiesIds is null))
                {
                    foreach (var id in SelectedRoomiesIds)
                    {
                        Roomie roomie = db.Roomies.Find(id);
                        if (roomie != null)
                        {
                            house.Roomies.Add(roomie);
                            roomie.HasHouse = true;
                            db.Entry(roomie).State = EntityState.Modified;

                        }
                    }
                    db.SaveChanges();
                }
                
                db.Entry(house).State = EntityState.Modified;
                db.SaveChanges();

                var houseRoomies = house.Roomies.ToList();
                if (houseRoomies.Count > 1)
                {
                    for (int i = 0; i < houseRoomies.Count; i++)
                    {
                        var otherRoomies = houseRoomies.Where(x => x != houseRoomies[i]).ToList();
                        for (int j = 0; j < otherRoomies.Count; j++)
                        {
                            GenerateMatch(houseRoomies[i], otherRoomies[j]);
                        }

                    }
                }
                

                return RedirectToAction("Index");
            }

            db.Houses.Attach(house);
            db.Entry(house).Collection("Roomies").Load();

            var roomiesIds = house.Roomies.Select(x => x.Id).ToList();
            ViewBag.SelectedRoomiesIds = db.Roomies.ToList().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = String.Format($"{x.FirstName} {x.LastName}"),
                Selected = roomiesIds.Any(y=>y == x.Id)
            });

            return View(house);
        }


        // GET: Administration/Houses/Delete/5
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

        // POST: Administration/Houses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            House house = db.Houses.Find(id);
            house.Roomies.Clear();

            db.Entry(house).State = EntityState.Deleted;
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

        public void GenerateMatch(Roomie roomieOne, Roomie roomieTwo)
        {
            RoomiesPair roomiesPair = new RoomiesPair();
            roomiesPair.RoomieOneId = roomieOne.Id;
            roomiesPair.RoomieTwoId = roomieTwo.Id;
            roomiesPair.MatchPercentage = homePageController.GetPercentage(roomieOne, roomieTwo);

            var roomieOneInDb = db.Roomies.Find(roomiesPair.RoomieOneId);
            roomieOneInDb.IsMatched = true;
            db.Entry(roomieOneInDb).State = EntityState.Modified;

            var roomieTwoInDb = db.Roomies.Find(roomiesPair.RoomieTwoId);
            roomieTwoInDb.IsMatched = true;
            db.Entry(roomieTwoInDb).State = EntityState.Modified;

            db.Entry(roomiesPair).State = EntityState.Added;
            db.SaveChanges();

        }

    }
}
