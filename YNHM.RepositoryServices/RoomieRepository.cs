using System;
using System.Collections.Generic;
using System.Linq;
using YNHM.Database;
using System.Data.Entity;
using YNHM.Entities.Models;

namespace YNHM.RepositoryServices
{
    public class RoomieRepository
    {
        readonly ApplicationDbContext db = new ApplicationDbContext();

        public List<Roomie> GetAll()
        {
            return db.Roomies.ToList();
        }

        public Roomie GetById(int? id)
        {
            return db.Roomies.Find(id);
        }

        public void Create (Roomie roomie)
        {
            db.Entry(roomie).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Edit(Roomie roomie)
        {
            db.Entry(roomie).State = EntityState.Modified;
            db.SaveChanges();
        }



        public void Delete(int id)
        {
            Roomie roomie = db.Roomies.Find(id);

            db.Entry(roomie).State = EntityState.Deleted;
            db.SaveChanges();
        }

        //public void Attach (Roomie roomie)
        //{
        //    //db.Roomies.Attach(roomie);
        //    //db.Entry(roomie).Collection("OwnsHouses").Load();
        //}

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
