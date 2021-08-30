namespace YNHM.Database.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using YNHM.Database.Models;
    using YNHM.Entities.TestResources;

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
                    Manager = geokthmonas,
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
                context.Houses.AddOrUpdate(h => h.Address, house);
            }
            #endregion

            #region people seed
            List<Person> syntheticPeople = new List<Person>()
            {
                new Person()
                {
                    FirstName="Vassilis",
                    LastName= "Kotsmanidis",
                    Age=34,
                    Email="vassilis.kotsman@gmail.com",
                    PersonId=2,
                    MatchPercent=0,
                    Phone="6945666666",
                    Facebook="https://www.facebook.com/vassilis.geko",
                    Description="Junior Web Developer fucking trying to fucking finish this fucking project!"
                },

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

            #region QuestionSets
            QuestionSet houseMateMatching = new QuestionSet()
            {
                Name = "Housemate Matching",
                Questions = new List<Question>()
                {
                    //Housework
                    new Question() { QuestionId = 1, Text = "How much does cleanliness matter in general?" },
                    new Question() { QuestionId = 2, Text = "How much are you bothered by a sink full with plates?" },
                    new Question() { QuestionId = 3, Text = "Do you mind the house being dusty?" },
                    new Question() { QuestionId = 4, Text = "Is cleaning the toilet every day important to you?" },
                    
                    //Noise
                    new Question() { QuestionId = 5, Text = "How much does noise matter in general?" },
                    new Question() { QuestionId = 6, Text = "Do you listen to music loud?" },
                    new Question() { QuestionId = 7, Text = "How much do you value quiet in the house" },
                    new Question() { QuestionId = 8, Text = "How bothered will you be with playing musical instruments?" },

                    //Food
                    new Question() { QuestionId = 9, Text = "Is a vegan or vegetarian diet important to you?" },
                    new Question() { QuestionId = 10, Text = "Do you cook every day?" },
                    new Question() { QuestionId = 11, Text = "How important is keeping your own groceries separate?" },
                    new Question() { QuestionId = 12, Text = "How important is eating with your housemates?" },

                    //Animals
                    new Question() { QuestionId = 13, Text = "Do you like animal companions?" },
                    new Question() { QuestionId = 14, Text = "How much do you mind caring for the housemate's animal companions, if they are absent?" },

                    //Friends
                    new Question() { QuestionId = 15, Text = "How much do you mind friends coming over?" },
                    new Question() { QuestionId = 16, Text = "Do you mind friends or significant others staying overnight?" },
                    new Question() { QuestionId = 17, Text = "How much does hanging out with your housemates matter?" },

                    //Smoking
                    new Question() { QuestionId = 18, Text = "Do you mind others smoking in the house?" },
                    new Question() { QuestionId = 19, Text = "Do you mind others smoking weed in the house?" }
                }
            };
            context.QuestionSets.Add(houseMateMatching);
            #endregion


            #region users seed
            #endregion
            context.SaveChanges();
        }
                
    }
}
