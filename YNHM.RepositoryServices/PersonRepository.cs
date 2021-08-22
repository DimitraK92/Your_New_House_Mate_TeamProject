using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YNHM.Database;
using System.Data.Entity;
using YNHM.Database.Models;

namespace YNHM.RepositoryServices
{
    public class PersonRepository
    {
        readonly ApplicationDbContext db = new ApplicationDbContext();

        public List<Person> GetAll()
        {
            return db.People.ToList();

        }

        public Person GetById(int? id)
        {
            return db.People.Find(id);
        }

        public void Create (Person person, IEnumerable<int?> SelectedHousesIds)
        {
            Attach(person);
            person.OwnsHouses.Clear();
            db.SaveChanges();

           if(!(SelectedHousesIds is null))
            {
                foreach(var id in SelectedHousesIds)
                {
                    House house = db.Houses.Find(id);
                    if(house != null)
                    {
                        person.OwnsHouses.Add(house);
                    }
                }
            }
            db.Entry(person).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Edit(Person person, IEnumerable<int?> SelectedHousesIds)
        {
            Attach(person);
           
            //person.OwnsHouses.Clear();
            ////db.SaveChangesAsync();
            //db.SaveChanges();

            //if(!(SelectedHousesIds is null))
            //{
            //    foreach (var id in SelectedHousesIds)
            //    {
            //        House house = db.Houses.Find(id);
            //        if(house != null)
            //        {
            //            person.OwnsHouses.Add(house);
            //        }
            //    }
            //}
            db.Entry(person).State = EntityState.Modified;
            //db.SaveChangesAsync();
            db.SaveChanges();
        }



        public void Delete(int id)
        {
            Person person = db.People.Find(id);
            person.OwnsHouses.Clear();

            db.Entry(person).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Attach (Person person)
        {
            db.People.Attach(person);
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
