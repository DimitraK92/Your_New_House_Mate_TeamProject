namespace YNHM.Database.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
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
                #region people seed
                List<Roomie> roomies = new List<Roomie>()
            {
                new Roomie()
                {
                    FirstName="Vassilis",
                    LastName= "Kotsmanidis",
                    Age=34,
                    Email="vassilis.kotsman@gmail.com",
                    Phone="6945666666",
                    Facebook="https://www.facebook.com/vassilis.geko",

                    IsSmoking = true,
                    IsCatPerson = true,
                    IsNoisy= true,
                    LikesCleaning = true,
                    IsVegan = true
                },
                new Roomie(){
                    FirstName ="Jane",
                    LastName = "Doe",
                    Age = 36,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    Phone = "0306900000000",
                    Email = @"janedoe@gmail.com",
                    Facebook = @"https://www.facebook.com/janedoe/",

                    IsSmoking = false,
                    IsCatPerson = false,
                    IsNoisy= false,
                    LikesCleaning = false,
                    IsVegan = false
                },
                new Roomie(){
                    FirstName ="Jim",
                    LastName = "Do",
                    Age = 10,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    Phone = "0306900000000",
                    Email = @"jimdo@gmail.com",
                    Facebook = @"https://www.facebook.com/jimdo/",

                    IsSmoking = true,
                    IsCatPerson = false,
                    IsNoisy= false,
                    LikesCleaning = false,
                    IsVegan = false
                },
                new Roomie(){
                    FirstName ="Max",
                    LastName = "Dont",
                    Age = 48,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    Phone = "0306900000000",
                    Email = @"maxdont@gmail.com",
                    Facebook = @"https://www.facebook.com/maxdont/",

                    IsSmoking = true,
                    IsCatPerson = true,
                    IsNoisy= false,
                    LikesCleaning = false,
                    IsVegan = false
                },
                new Roomie(){
                    FirstName ="Min",
                    LastName = "Donot",
                    Age = 82,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    Phone = "0306900000000",
                    Email = @"mindonot@gmail.com",
                    Facebook = @"https://www.facebook.com/mindonot/",

                    IsSmoking = true,
                    IsCatPerson = true,
                    IsNoisy= true,
                    LikesCleaning = false,
                    IsVegan = false
                },
                new Roomie(){
                    FirstName ="Jill",
                    LastName = "Cannot",
                    Age = 30,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    Phone = "0306900000000",
                    Email = @"jillcannot@gmail.com",
                    Facebook = @"https://www.facebook.com/jillcannot/",

                    IsSmoking = true,
                    IsCatPerson = true,
                    IsNoisy= true,
                    LikesCleaning = true,
                    IsVegan = false
                },
                new Roomie(){
                    FirstName ="Jake",
                    LastName = "Shallnot",
                    Age = 63,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    Phone = "0306900000000",
                    Email = @"jakeshallnot@gmail.com",
                    Facebook = @"https://www.facebook.com/jakeshallnot/",

                    IsSmoking = true,
                    IsCatPerson = true,
                    IsNoisy= true,
                    LikesCleaning = true,
                    IsVegan = true
                },
                new Roomie(){
                    FirstName ="Bill",
                    LastName = "Shall",
                    Age = 27,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    Phone = "0306900000000",
                    Email = @"billshall@gmail.com",
                    Facebook = @"https://www.facebook.com/billshall/",

                    IsSmoking = true,
                    IsCatPerson = true,
                    IsNoisy= false,
                    LikesCleaning = true,
                    IsVegan = true
                },
                new Roomie(){
                    FirstName ="Andy",
                    LastName = "Can",
                    Age = 51,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    Phone = "0306900000000",
                    Email = @"andycan@gmail.com",
                    Facebook = @"https://www.facebook.com/andycan/",

                    IsSmoking = true,
                    IsCatPerson = false,
                    IsNoisy= true,
                    LikesCleaning = false,
                    IsVegan = true
                },
                new Roomie(){
                    FirstName ="Andria",
                    LastName = "Could",
                    Age = 18,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    Phone = "0306900000000",
                    Email = @"andriacould@gmail.com",
                    Facebook = @"https://www.facebook.com/andriacould/",

                    IsSmoking = false,
                    IsCatPerson = false,
                    IsNoisy= true,
                    LikesCleaning = true,
                    IsVegan = false

                },
                new Roomie(){
                    FirstName ="Maria",
                    LastName = "Couldnot",
                    Age = 36,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    Phone = "0306900000000",
                    Email = @"mariacouldnot@gmail.com",
                    Facebook = @"https://www.facebook.com/mariacouldnot/",

                    IsSmoking = false,
                    IsCatPerson = true,
                    IsNoisy= false,
                    LikesCleaning = true,
                    IsVegan = false
                }
            };
                foreach (var roomie in roomies)
                {
                    if (roomie.Age%5==0)
                    {
                        roomie.IsMatched = true;
                    }

                    if (roomie.FirstName.Contains("i"))
                    {
                        roomie.HasHouse = true;
                    }
                    context.Roomies.AddOrUpdate(p => new { p.FirstName, p.LastName }, roomie);
                }
                #endregion

                context.SaveChanges();
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
