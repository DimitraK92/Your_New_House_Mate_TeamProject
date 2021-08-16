namespace YNHM.Database.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using YNHM.Database.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            #region houses seed
            Person geokthmonas = new Person()
            {
                FirstName = "Gianna",
                LastName = "Mesitria",
                Age = 36,
                PhotoUrl = @"~/Models/FakeImages/person1.jpg",
                MatchPercent = 95,
                Phone = "694 656 6566",
                Email = @"gianna.mesitria@gmail.com",
                Facebook = @"https://el-gr.facebook.com/generic-user-name",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
            };
            context.People.AddOrUpdate(p => new { p.FirstName, p.LastName }, geokthmonas);
            Random random = new Random();
            string[] addresses = new string[]
            {
                "Fokionos Negri 45",
                "Kypselis 32",
                "Frynis 56",
                "Patision 165",
                "Kerkyras 98",
                "Naxou 134",
                "Themistokleous 87",
                "Kallidromiou 60",
                "Voulgaroktonou 1",
                "Agias Zonis 27"
            };
            List<House> houses = new List<House>();
            foreach (var address in addresses)
            {
                var house = new House()
                {
                    Title = "Ugly exterior with surprising interior",
                    Address = address,
                    PostalCode = (10000 + random.Next(1000, 9999)).ToString(),
                    Area = random.Next(60, 200),
                    Floor = random.Next(6),
                    Bedrooms = random.Next(1, 3),
                    Rent = random.Next(250, 400),
                    District = "City Center",
                    MapLocation = "https://goo.gl/maps/2LMwmuBWZW5SvDEe6",
                    Photos = CreateSyntheticPhotos(context),
                    Manager = geokthmonas
                };
                context.Houses.AddOrUpdate(h => h.Address, house);
            }
            #endregion

            #region people seed
            List<Person> syntheticPeople = new List<Person>()
            {
                new Person(){
                    FirstName ="Jane",
                    LastName = "Doe",
                    Age = 36,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    MatchPercent = 95,
                    Phone = "0306900000000",
                    Email = @"janedoe@gmail.com",
                    Facebook = @"https://www.facebook.com/janedoe/",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                },
                new Person(){
                    FirstName ="Jim",
                    LastName = "Do",
                    Age = 10,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    MatchPercent = 32,
                    Phone = "0306900000000",
                    Email = @"jimdo@gmail.com",
                    Facebook = @"https://www.facebook.com/jimdo/",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Orci phasellus egestas tellus rutrum."
                },
                new Person(){
                    FirstName ="Max",
                    LastName = "Dont",
                    Age = 48,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    MatchPercent = 95,
                    Phone = "0306900000000",
                    Email = @"maxdont@gmail.com",
                    Facebook = @"https://www.facebook.com/maxdont/",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                },
                new Person(){
                    FirstName ="Min",
                    LastName = "Donot",
                    Age = 82,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    MatchPercent = 29,
                    Phone = "0306900000000",
                    Email = @"mindonot@gmail.com",
                    Facebook = @"https://www.facebook.com/mindonot/",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Orci phasellus egestas tellus rutrum."
                },
                new Person(){
                    FirstName ="Jill",
                    LastName = "Cannot",
                    Age = 30,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    MatchPercent = 77,
                    Phone = "0306900000000",
                    Email = @"jillcannot@gmail.com",
                    Facebook = @"https://www.facebook.com/jillcannot/",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                },
                new Person(){
                    FirstName ="Jake",
                    LastName = "Shallnot",
                    Age = 63,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    MatchPercent = 63,
                    Phone = "0306900000000",
                    Email = @"jakeshallnot@gmail.com",
                    Facebook = @"https://www.facebook.com/jakeshallnot/",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Orci phasellus egestas tellus rutrum."
                },
                new Person(){
                    FirstName ="Bill",
                    LastName = "Shall",
                    Age = 27,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    MatchPercent = 1,
                    Phone = "0306900000000",
                    Email = @"billshall@gmail.com",
                    Facebook = @"https://www.facebook.com/billshall/",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                },
                new Person(){
                    FirstName ="Andy",
                    LastName = "Can",
                    Age = 51,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    MatchPercent = 48,
                    Phone = "0306900000000",
                    Email = @"andycan@gmail.com",
                    Facebook = @"https://www.facebook.com/andycan/",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                },
                new Person(){
                    FirstName ="Andria",
                    LastName = "Could",
                    Age = 18,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    MatchPercent = 87,
                    Phone = "0306900000000",
                    Email = @"andriacould@gmail.com",
                    Facebook = @"https://www.facebook.com/andriacould/",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Orci phasellus egestas tellus rutrum."
                },
                new Person(){
                    FirstName ="Maria",
                    LastName = "Couldnot",
                    Age = 36,
                    PhotoUrl = @"https://thispersondoesnotexist.com/",
                    MatchPercent = 95,
                    Phone = "0306900000000",
                    Email = @"mariacouldnot@gmail.com",
                    Facebook = @"https://www.facebook.com/mariacouldnot/",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                }
            };
            foreach (var person in syntheticPeople)
            {
                context.People.AddOrUpdate(p => new { p.FirstName, p.LastName }, person);
            }
            #endregion
            context.SaveChanges();
        }

        private List<Photo> CreateSyntheticPhotos(ApplicationDbContext context)
        {
            HashSet<string> photos = new HashSet<string>()
            {
                @"https://i.pinimg.com/originals/05/96/1e/05961e1ce9e6492a11292042263c44de.jpg",
                @"http://cdn.home-designing.com/wp-content/uploads/2014/10/simple-small-bedroom.jpeg",
                @"https://cdn.decoratorist.com/wp-content/uploads/design-house-interior-contemporary-living-room-367286.jpg",
                @"https://hative.com/wp-content/uploads/2013/05/white-small-bathroom-decorating-layout-2502.jpg",
                @"https://i.pinimg.com/originals/59/05/a4/5905a473f3cc38b72e79a5ee2bc40705.jpg",
                @"https://i.pinimg.com/originals/4d/19/59/4d195933bb3df785114a7af88b02fdf1.jpg"
            };
            foreach (var photo in photos)
            {
                context.Photos.AddOrUpdate(p => p.PhotoUrl, new Photo() { PhotoUrl = photo });
            }
            try
            {
                context.SaveChanges();
                return context.Photos.Where(p => photos.Contains(p.PhotoUrl)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
