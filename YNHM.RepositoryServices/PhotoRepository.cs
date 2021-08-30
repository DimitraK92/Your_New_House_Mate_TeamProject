using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using YNHM.Database;
using YNHM.Entities.Models;

namespace YNHM.RepositoryServices
{
    public class PhotoRepository
    {
        readonly ApplicationDbContext db = new ApplicationDbContext();

        public List<Photo> GetAll()
        {
            return db.Photos.ToList();
        }

        public Photo GetById(int? id)
        {
            return db.Photos.Find(id);
        }

        public void Create(Photo photo)
        {
           
            db.Entry(photo).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Edit(Photo photo)
        {
           
            db.Entry(photo).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Photo photo = db.Photos.Find(id);
            if (!(photo is null))
            {
                db.Entry(photo).State = EntityState.Deleted;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("The photo could not be deleted.");
            }
        }

        readonly bool disposed = false;
        protected virtual void Dispose(bool disposing)
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
