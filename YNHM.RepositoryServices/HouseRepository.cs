using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YNHM.Database;
using YNHM.Database.Models;

namespace YNHM.RepositoryServices
{
    class HouseRepository
    {
        readonly ApplicationDbContext db = new ApplicationDbContext();

        public List<House> GetAll()
        {
            return db.Houses.ToList();          
        }

        public House GetById(int? id)
        {
            return db.Houses.Find(id);
        }

        public void Create(House house, IEnumerable<int?> SelectedPhotoIds)
        {
            Attach(house);
            house.Photos.Clear();
            db.SaveChanges();

            if (!(SelectedPhotoIds is null))
            {
                foreach (var id in SelectedPhotoIds)
                {
                    Photo photo = db.Photos.Find(id);
                    if (photo != null)
                    {
                        house.Photos.Add(photo);
                    }
                }
            }
            db.Entry(house).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Edit(House house, IEnumerable<int?> SelectedPhotoIds)
        {
            Attach(house);
            house.Photos.Clear();
            db.SaveChanges();

            if (!(SelectedPhotoIds is null))
            {
                foreach (var id in SelectedPhotoIds)
                {
                    Photo photo = db.Photos.Find(id);
                    if (photo != null)
                    {
                        house.Photos.Add(photo);
                    }
                }
            }
            db.Entry(house).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            House house = db.Houses.Find(id);
            house.Photos.Clear();

            db.Entry(house).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Attach(House house)
        {
            db.Houses.Attach(house);
            db.Entry(house).Collection("Photos").Load();
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
