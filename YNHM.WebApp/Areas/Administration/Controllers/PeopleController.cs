using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YNHM.Database;
using YNHM.Database.Models;
using YNHM.Database.Models.ViewModels;
using YNHM.RepositoryServices;


namespace YNHM.WebApp.Areas.Administration.Controllers
{
    public class PeopleController : Controller
    {
        readonly ApplicationDbContext db = new ApplicationDbContext();
        readonly PersonRepository pr = new PersonRepository();

        // GET: People
        public ActionResult Index()
        {
            var people = pr.GetAll();

            return View(people);
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = pr.GetById(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            PersonCreateViewModel vm = new PersonCreateViewModel();

            return View(vm);
        }


        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,FirstName,LastName,Age,MatchPercent,Phone,Email,Facebook,Description,PhotoUrl")] Person person, IEnumerable<int?> SelectedHousesIds)
        {
            if (ModelState.IsValid)
            {
                pr.Create(person, SelectedHousesIds);                
                return RedirectToAction("Index");
            }

            PersonCreateViewModel vm = new PersonCreateViewModel();
            
            return View(vm);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = pr.GetById(id);
            if (person == null)
            {
                return HttpNotFound();
            }

            PersonEditViewModel vm = new PersonEditViewModel(person);

            return View(vm);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,FirstName,LastName,Age,MatchPercent,Phone,Email,Facebook,Description,PhotoUrl")] Person person, IEnumerable<int?> SelectedHousesIds)
        {
            if (ModelState.IsValid)
            {
                pr.Edit(person, SelectedHousesIds);
                return RedirectToAction("Index");
            }

            pr.Attach(person);
            PersonEditViewModel vm = new PersonEditViewModel(person);

            return View(vm);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = pr.GetById(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pr.Delete(id);
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
