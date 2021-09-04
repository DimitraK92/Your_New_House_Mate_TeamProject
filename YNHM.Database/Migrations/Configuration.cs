namespace YNHM.Database.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using YNHM.Entities.Models;
    using YNHM.Entities.TestResources;

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
                List<HouseSeeker> syntheticPeople = new List<HouseSeeker>()
            {
                new HouseSeeker()
                {
                    FirstName="Vassilis",
                    LastName= "Kotsmanidis",
                    Age=34,
                    Email="vassilis.kotsman@gmail.com",
                    MatchPercent=0,
                    Phone="6945666666",
                    Facebook="https://www.facebook.com/vassilis.geko",
                    Description="Junior Web Developer fucking trying to fucking finish this fucking project!"
                },
                new HouseSeeker(){
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
                new HouseSeeker(){
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
                new HouseSeeker(){
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
                new HouseSeeker(){
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
                new HouseSeeker(){
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
                new HouseSeeker(){
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
                new HouseSeeker(){
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
                new HouseSeeker(){
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
                new HouseSeeker(){
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
                new HouseSeeker(){
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
                    context.HouseSeekers.AddOrUpdate(p => new { p.FirstName, p.LastName }, person);
                }
                #endregion
                context.SaveChanges();

                #region houses seed
                Random random = new Random();
                string[] addresses = new string[]
                {
                    "Fokionos Negri 45",
                    "Kypselis 32",
                    "Frynis 56",
                    "Patision 165",
                    "Kerkyras 98"
                    //,
                    //"Naxou 134",
                    //"Themistokleous 87",
                    //"Kallidromiou 60",
                    //"Voulgaroktonou 1",
                    //"Agias Zonis 27"
                };

                List<House> houses = new List<House>();
                foreach (var address in addresses)
                {
                    #region photo seeding
                    List<Photo> photos = new List<Photo>()
                    {
                        new Photo(){PhotoUrl = @"https://i.pinimg.com/originals/05/96/1e/05961e1ce9e6492a11292042263c44de.jpg" },
                        new Photo(){PhotoUrl = @"http://cdn.home-designing.com/wp-content/uploads/2014/10/simple-small-bedroom.jpeg" },
                        new Photo(){PhotoUrl = @"https://cdn.decoratorist.com/wp-content/uploads/design-house-interior-contemporary-living-room-367286.jpg" },
                        new Photo(){PhotoUrl = @"https://hative.com/wp-content/uploads/2013/05/white-small-bathroom-decorating-layout-2502.jpg" },
                        new Photo(){PhotoUrl = @"https://i.pinimg.com/originals/59/05/a4/5905a473f3cc38b72e79a5ee2bc40705.jpg" },
                        new Photo(){PhotoUrl = @"https://i.pinimg.com/originals/4d/19/59/4d195933bb3df785114a7af88b02fdf1.jpg" }
                    };
                    context.Photos.AddRange(photos);
                    #endregion
                    var house = new House()
                    {
                        Title = "Apartment",
                        Address = address,
                        PostalCode = (10000 + random.Next(1000, 9999)).ToString(),
                        Area = random.Next(60, 200),
                        Floor = random.Next(6),
                        Bedrooms = random.Next(1, 3),
                        Rent = random.Next(250, 400),
                        District = "City Center",
                        MapLocation = "https://goo.gl/maps/2LMwmuBWZW5SvDEe6",
                        Photos = photos,
                        PageViews = 0,
                        //TODO: KOSTAS test view at edge case none present
                        ElevatorInBuilding = random.Next(2) == 0,
                        FreeWiFi = random.Next(2) == 0,
                        Parking = random.Next(2) == 0,
                        AirCondition = random.Next(2) == 0,
                        PetFriendly = random.Next(2) == 0,
                        OutdoorSeating = random.Next(2) == 0,
                        WheelchairFriendly = random.Next(2) == 0
                    };
                    houses.Add(house);
                    //context.Houses.AddOrUpdate(h => h.Address, house);
                }
                #endregion


                #region People and houses

                var people = context.HouseSeekers.ToList();
                for (int i = 0; i < 5; i++)
                {
                    var p = people[i];
                    var h = houses[i];
                    
                    p.House = h;

                    context.HouseSeekers.AddOrUpdate(p);

                    h.HouseSeekerId = p.HouseSeekerId;
                    h.HouseSeeker = p;

                    context.Houses.Add(h);
                }
                #endregion
                context.SaveChanges();

                
                #region QuestionSets

                List<Question> questions = new List<Question>()
                {
                    //Housework
                    new Question() { Text = "How much does cleanliness matter in general?" },
                    new Question() { Text = "How much are you bothered by a sink full with plates?" },
                    new Question() { Text = "Do you mind the house being dusty?" },
                    new Question() { Text = "Is cleaning the toilet every day important to you?" },

                    //Noise
                    new Question() { Text = "How much does noise matter in general?" },
                    new Question() { Text = "Do you listen to music loud?" },
                    new Question() { Text = "How much do you value quiet in the house" },
                    new Question() { Text = "How bothered will you be with playing musical instruments?" },

                    //Food
                    new Question() { Text = "Is a vegan or vegetarian diet important to you?" },
                    new Question() { Text = "Do you cook every day?" },
                    new Question() { Text = "How important is keeping your own groceries separate?" },
                    new Question() { Text = "How important is eating with your housemates?" },

                    //Animals
                    new Question() { Text = "Do you like animal companions?" },
                    new Question() { Text = "How much do you mind caring for the housemate's animal companions, if they are absent?" },

                    //Friends
                    new Question() { Text = "How much do you mind friends coming over?" },
                    new Question() { Text = "Do you mind friends or significant others staying overnight?" },
                    new Question() { Text = "How much does hanging out with your housemates matter?" },

                    //Smoking
                    new Question() { Text = "Do you mind others smoking in the house?" },
                    new Question() { Text = "Do you mind others smoking weed in the house?" }
                };

                foreach (var question in questions)
                {
                    context.Questions.Add(question);

                }

                QuestionSet houseMateMatching = new QuestionSet()
                {
                    Name = "Housemate Matching",
                    Questions = new List<Question>()
                };

                foreach (var q in context.Questions)
                {
                    houseMateMatching.Questions.Add(q);
                }

                context.QuestionSets.Add(houseMateMatching);
                #endregion


                #region users seed
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
