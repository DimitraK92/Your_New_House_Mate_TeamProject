namespace YNHM.Database.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using YNHM.Entities.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }


        protected override void Seed(ApplicationDbContext context)
        {

            try
            {
                #region roomies seed
                //List<Roomie> roomies = new List<Roomie>()
                //{
                Roomie r1 = new Roomie()
                {
                    FirstName = "Vassilis",
                    LastName = "Kotsmanidis",
                    Age = 34,
                    Email = "vassilis.kotsman@gmail.com",
                    Phone = "6945666666",
                    Facebook = "https://www.facebook.com/vassilis.geko",

                    IsSmoking = true,
                    IsCatPerson = true,
                    IsNoisy = true,
                    LikesCleaning = true,
                    IsVegan = true,

                };

                Roomie r2 = new Roomie() 
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Age = 36,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    Phone = "0306900000000",
                    Email = @"janedoe@gmail.com",
                    Facebook = @"https://www.facebook.com/janedoe/",

                    IsSmoking = false,
                    IsCatPerson = false,
                    IsNoisy = false,
                    LikesCleaning = false,
                    IsVegan = false,

                    HasHouse = true,
                    IsMatched = true

                };

                Roomie r3 = new Roomie()
                {
                    FirstName = "Jim",
                    LastName = "Do",
                    Age = 10,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    Phone = "0306900000000",
                    Email = @"jimdo@gmail.com",
                    Facebook = @"https://www.facebook.com/jimdo/",

                    IsSmoking = true,
                    IsCatPerson = false,
                    IsNoisy = false,
                    LikesCleaning = false,
                    IsVegan = false,

                    HasHouse = true,
                    IsMatched = true

                };
                Roomie r4 = new Roomie()
                {
                    FirstName = "Max",
                    LastName = "Dont",
                    Age = 48,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    Phone = "0306900000000",
                    Email = @"maxdont@gmail.com",
                    Facebook = @"https://www.facebook.com/maxdont/",

                    IsSmoking = true,
                    IsCatPerson = true,
                    IsNoisy = false,
                    LikesCleaning = false,
                    IsVegan = false,

                    HasHouse = true
                };

                Roomie r5 = new Roomie() {
                    FirstName = "Min",
                    LastName = "Donot",
                    Age = 82,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    Phone = "0306900000000",
                    Email = @"mindonot@gmail.com",
                    Facebook = @"https://www.facebook.com/mindonot/",

                    IsSmoking = true,
                    IsCatPerson = true,
                    IsNoisy = true,
                    LikesCleaning = false,
                    IsVegan = false,

                    IsMatched = true
                };

                Roomie r6 = new Roomie() {
                    FirstName = "Jill",
                    LastName = "Cannot",
                    Age = 30,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    Phone = "0306900000000",
                    Email = @"jillcannot@gmail.com",
                    Facebook = @"https://www.facebook.com/jillcannot/",

                    IsSmoking = true,
                    IsCatPerson = true,
                    IsNoisy = true,
                    LikesCleaning = true,
                    IsVegan = false,

                    IsMatched = true
                };

                Roomie r7 = new Roomie() {
                    FirstName = "Jake",
                    LastName = "Shallnot",
                    Age = 63,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    Phone = "0306900000000",
                    Email = @"jakeshallnot@gmail.com",
                    Facebook = @"https://www.facebook.com/jakeshallnot/",

                    IsSmoking = true,
                    IsCatPerson = true,
                    IsNoisy = true,
                    LikesCleaning = true,
                    IsVegan = true,

                    HasHouse = true
                };

                Roomie r8 = new Roomie() {
                    FirstName = "Bill",
                    LastName = "Shall",
                    Age = 27,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    Phone = "0306900000000",
                    Email = @"billshall@gmail.com",
                    Facebook = @"https://www.facebook.com/billshall/",

                    IsSmoking = true,
                    IsCatPerson = true,
                    IsNoisy = false,
                    LikesCleaning = true,
                    IsVegan = true
                };

                Roomie r9 = new Roomie() {
                    FirstName = "Andy",
                    LastName = "Can",
                    Age = 51,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    Phone = "0306900000000",
                    Email = @"andycan@gmail.com",
                    Facebook = @"https://www.facebook.com/andycan/",

                    IsSmoking = true,
                    IsCatPerson = false,
                    IsNoisy = true,
                    LikesCleaning = false,
                    IsVegan = true,
                };

                Roomie r10 = new Roomie() {
                    FirstName = "Andria",
                    LastName = "Could",
                    Age = 18,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    Phone = "0306900000000",
                    Email = @"andriacould@gmail.com",
                    Facebook = @"https://www.facebook.com/andriacould/",

                    IsSmoking = false,
                    IsCatPerson = false,
                    IsNoisy = true,
                    LikesCleaning = true,
                    IsVegan = false

                };

                Roomie r11 = new Roomie()
                {
                    FirstName = "Maria",
                    LastName = "Couldnot",
                    Age = 36,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    Phone = "0306900000000",
                    Email = @"mariacouldnot@gmail.com",
                    Facebook = @"https://www.facebook.com/mariacouldnot/",

                    IsSmoking = false,
                    IsCatPerson = true,
                    IsNoisy = false,
                    LikesCleaning = true,
                    IsVegan = false
                };
                //};
                //foreach (var roomie in roomies)
                //{
                //    if (roomie.Age%5==0)
                //    {
                //        roomie.IsMatched = true;
                //    }

                //    //if (!roomie.FirstName.Contains("i"))
                //    //{
                //    //    roomie.HasHouse = true;
                //    //}

                //    //context.Roomies.AddOrUpdate(p => new { p.FirstName, p.LastName }, roomie);
                //}
                #endregion
                #region houses_seed

                House h1 = new House()
                {
                    Address = "Fokionos Negri 45",
                    District = "Kipseli",
                    Floor = 2,
                    Area = 123,
                    Bedrooms = 2,
                    Rent = 250,
                };
                House h2 = new House()
                {
                    Address = "Kerkiras 98",
                    District = "Kipseli",
                    Floor = 3,
                    Area = 68,
                    Bedrooms = 2,
                    Rent = 200,
                };
                House h3 = new House()
                {
                    Address = "Frinis 56",
                    District = "Pagkrati",
                    Floor = 5,
                    Area = 90,
                    Bedrooms = 3,
                    Rent = 350,
                };
                House h4 = new House()
                {
                    Address = "Markou Mpotsari 32",
                    District = "Koukaki",
                    Floor = 4,
                    Area = 73,
                    Bedrooms = 3,
                    Rent = 300,                   
                };
                #endregion

                #region houses-roomies
                h1.Roomies.Add(r2);
                h2.Roomies.Add(r3);
                h3.Roomies.Add(r4);
                h4.Roomies.Add(r7);

                r2.House = h1;
                r3.House = h2;
                r4.House = h3;
                r7.House = h4;

                #endregion
                #region add to Db

                context.Houses.AddOrUpdate(p => new { p.Address, p.District }, h1,h2,h3,h4);
                context.Roomies.AddOrUpdate(p => new { p.FirstName, p.LastName }, r1,r5,r6,r8,r9,r10,r11);
                context.SaveChanges();

                #endregion

            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

    }
}
