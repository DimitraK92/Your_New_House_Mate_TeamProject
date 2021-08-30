using System;
using System.Collections.Generic;
using System.Linq;
using YNHM.Database;
using System.Data.Entity;
using YNHM.Entities.Models;

namespace YNHM.RepositoryServices
{
    public class HouseSeekerRepository
    {
        readonly ApplicationDbContext db = new ApplicationDbContext();

        public List<HouseSeeker> GetAll()
        {
            return db.HouseSeekers.ToList();

        }

        public HouseSeeker GetById(int? id)
        {
            return db.HouseSeekers.Find(id);
        }

        //TODO: VASSILIS: Fix owns houses
        public void Create (HouseSeeker person, IEnumerable<int?> SelectedHousesIds)
        {
            Attach(person);
            //person.OwnsHouses.Clear();
            db.SaveChanges();

           if(!(SelectedHousesIds is null))
            {
                foreach(var id in SelectedHousesIds)
                {
                    House house = db.Houses.Find(id);
                    if(house != null)
                    {
                        //person.OwnsHouses.Add(house);
                    }
                }
            }
            db.Entry(person).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Edit(HouseSeeker person, IEnumerable<int?> SelectedHousesIds)
        {
            Attach(person);
            person.OwnsHouses.Clear();
            db.SaveChangesAsync();

            if (!(SelectedHousesIds is null))
            {
                foreach (var id in SelectedHousesIds)
                {
                    House house = db.Houses.Find(id);
                    if (house != null)
                    {
                        person.OwnsHouses.Add(house);
                    }
                }
            }
            db.Entry(person).State = EntityState.Modified;
            db.SaveChanges();
        }



        public void Delete(int id)
        {
            Person person = db.HouseSeekers.Find(id);
            //person.OwnsHouses.Clear();

            db.Entry(person).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Attach (HouseSeeker person)
        {
            db.HouseSeekers.Attach(person);
            db.Entry(person).Collection("OwnsHouses").Load();
        }

        readonly bool disposed = false;
        protected virtual void Dispose (bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }   
}
