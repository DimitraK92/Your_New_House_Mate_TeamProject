namespace YNHM.Database.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
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
                #region roomies seed
                string[] firstNames =   { "Maria", "Mohammed", "Wei", "Yan", "John",
                                        "Helen", "Christina", "David","Ahmed","Astridr",
                                        "Anna", "Luis","Fatima","Olga", "Richard",
                                        "Victor", "Sandra", "Ming", "Marina","Carmen",
                                        "Clarissa", "Melpomene","James","Camina","Amos",
                                        "Klaes", "Julie","Jules-Pierre","Fred","Arjun",
                                        "Elvi","Shed","Cotyar","Filip","Josephus",
                                        "Frodo","Sam","Merry","Pippin","Gandalf",
                                        "Aragorn","Legolas","Gimli","Boromir","Morgoth",
                                        "Melkor","Sauron","Ellaria","Gloin","Glorfindel",
                                        "Eowyn","Arwen","Balin","Celebrimbor","Denethor",
                                        "Elendil","Elrond","Galadriel","Hurin","Turin",
                                        "Nienor","Luthien","Saruman"};

                string[] lastNames =    {"Wang","Nagata","Holden","Burton","Kamal",
                                     "Dawes","Anderson","Avasarala","Inaros", "Mao",
                                     "Johnson","Miller","Wei","Volovodof","Shaddid",
                                     "Drummer","Ashford","Cortazar","Errinwright","Murtry",
                                     "Pereira","Ren","Skywalker","Lannister","Stark",
                                     "Baratheon","Martell","Targaryen","Arryn","Tyrell",
                                     "Tully","Greyjoy","Allgood","Allyrion","Amber",
                                     "Bolton","Blount","Bar Emmon","Celtigar","Velaryon",
                                     "Sunglass","Brune","Blackfyre","Slynt","Mormont","Cerwyn"};

                string[] photos = { @"Models\FakeImages\person1.jpg", @"Models\FakeImages\person2.jpg",
                                    @"Models\FakeImages\person3.jpg",@"Models\FakeImages\person4.jpg",
                                    @"Models\FakeImages\person5.jpg",@"Models\FakeImages\person6.jpg",
                                    @"Models\FakeImages\person7.jpg",@"Models\FakeImages\person8.jpg",
                                    @"Models\FakeImages\person9.jpg",@"Models\FakeImages\person10.jpg",
                                    @"Models\FakeImages\person11.jpg",@"Models\FakeImages\person12.jpg",
                                    @"Models\FakeImages\person13.jpg",@"Models\FakeImages\person14.jpg",
                                    @"Models\FakeImages\person15.jpg",@"Models\FakeImages\person16.jpg",
                                    @"Models\FakeImages\person17.jpg",@"Models\FakeImages\person18.jpg",
                                    @"Models\FakeImages\person19.jpg",@"Models\FakeImages\person20.jpg",
                                    @"Models\FakeImages\person21.jpg"};

                Random rand = new Random();
                for (int i = 0; i < 100; i++)
                {
                    string firstName = firstNames[rand.Next(0, firstNames.Length)];
                    string lastName = lastNames[rand.Next(0, lastNames.Length)];
                    string photoUrl = photos[rand.Next(0, photos.Length)];
                    string email = $"{firstName}.{lastName}@gmail.com";
                    string phone = $"69{rand.Next(11111111, 100000000)}";
                    int age = rand.Next(18, 101);

                    Roomie r = new Roomie()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        Phone = phone,
                        Email = email,
                        IsMatched = false,
                        HasHouse = false,
                        PhotoUrl = photoUrl
                    };

                    context.Roomies.AddOrUpdate(p => new { p.FirstName, p.LastName }, r);
                };

                context.SaveChanges();

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

                Roomie r5 = new Roomie()
                {
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

                Roomie r6 = new Roomie()
                {
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

                Roomie r7 = new Roomie()
                {
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

                Roomie r8 = new Roomie()
                {
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

                Roomie r9 = new Roomie()
                {
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

                Roomie r10 = new Roomie()
                {
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

                Roomie r12 = new Roomie()
                {
                    FirstName = "Dimitra",
                    LastName = "Kamni",
                    Age = 28,
                    Email = "dimitra.kam@gmail.com",
                    Phone = "6945123456"
                };

                context.Roomies.AddOrUpdate(p => new { p.FirstName, p.LastName }, r1,r2,r3,r4,r5,r6,r7,r8,r9,r10,r11,r12);
                context.SaveChanges();


                #endregion


                #region houses_seed

                string[] streets =
{
                    "Ipirou", "Patission","Panepistimiou", "Frynis","Kerkyras",
                    "Pl. Koliatsou","Skiathou","Skopelou","Kykladon","Tritis Septemvriou",
                    "Agiou Nikolaou","Agiou Georgiou","Agias Annas","Agias Zonis","Agias Kiriakis",
                    "Ari Velouchioti","Angelou Sikelianou","Kosma Aitolou","Athinas","Iras",
                    "Afroditis","Dia","Autokratoron Angelon","Themistokleous","Perikleous"
                };

                string[] districts =
                {
                    "Center","Zografou","Exarcheia","Kolonaki","Kato Patissia",
                    "Kypseli","Kaisariani","Perama","Peiraias","Pasalimani",
                    "Nea Smyrni","Kallithea"
                };


                for (int i = 0; i < streets.Length; i++)
                {
                    string address = $"{streets[rand.Next(0, streets.Length)]} {rand.Next(1, 350)}";
                    string district = $"{districts[rand.Next(0, districts.Length)]}";
                    int rooms = rand.Next(2, 6);
                    int floor = rand.Next(0, 11);
                    int rent = 0;
                    int area = 0;

                    if (rooms > 2)
                    {
                        area = rand.Next(70, 200);
                    }
                    else
                    {
                        area = rand.Next(45, 200);
                    }

                    if (area > 100)
                    {
                        rent = rand.Next(350, 601);
                    }
                    else
                    {
                        rent = rand.Next(200, 601);
                    }

                    House h = new House()
                    {
                        Address = address,
                        District = district,
                        Area = area,
                        Bedrooms = rooms,
                        Floor = floor,
                        Rent = rent
                    };
                    context.Houses.Add(h);
                };
                context.SaveChanges();

                var houses = context.Houses.ToList();
                var rms = context.Roomies.ToList();

                for (int i = 0; i < houses.Count; i++)
                {
                    if (!rms[i].HasHouse)
                    {
                        houses[i].Roomies.Add(rms[i]);
                        rms[i].House = houses[i];
                        rms[i].HouseId = houses[i].Id;
                        rms[i].HasHouse = true;
                    }
                    context.Houses.AddOrUpdate(houses[i]);
                    context.Roomies.AddOrUpdate(rms[i]);
                }
                context.SaveChanges();


                //House h1 = new House()
                //{
                //    Address = "Fokionos Negri 45",
                //    District = "Kipseli",
                //    Floor = 2,
                //    Area = 123,
                //    Bedrooms = 2,
                //    Rent = 250,
                //};
                //House h2 = new House()
                //{
                //    Address = "Kerkiras 98",
                //    District = "Kipseli",
                //    Floor = 3,
                //    Area = 68,
                //    Bedrooms = 2,
                //    Rent = 200,
                //};
                //House h3 = new House()
                //{
                //    Address = "Frinis 56",
                //    District = "Pagkrati",
                //    Floor = 5,
                //    Area = 90,
                //    Bedrooms = 3,
                //    Rent = 350,
                //};
                //House h4 = new House()
                //{
                //    Address = "Markou Mpotsari 32",
                //    District = "Koukaki",
                //    Floor = 4,
                //    Area = 73,
                //    Bedrooms = 3,
                //    Rent = 300,
                //};
                #endregion

                #region houses-roomies
                //h1.Roomies.Add(r2);
                //h2.Roomies.Add(r3);
                //h3.Roomies.Add(r4);
                //h4.Roomies.Add(r7);

                //r2.House = h1;
                //r3.House = h2;
                //r4.House = h3;
                //r7.House = h4;

                #endregion
                #region add to Db

                //context.Houses.AddOrUpdate(p => new { p.Address, p.District }, h1, h2, h3, h4);
                //context.Roomies.AddOrUpdate(p => new { p.FirstName, p.LastName }, r1, r5, r6, r8, r9, r10, r11);
                //context.SaveChanges();

                #endregion

                #region Tests
                List<Question> questions = new List<Question>()
                {
                    //Housework
                    new Question() { Text = "Does cleanliness matter in general?" },
                    new Question() { Text = "Are you bothered by a sink full with plates?" },
                    new Question() { Text = "Do you mind the house being dusty?" },
                    new Question() { Text = "Is cleaning the toilet every day important to you?" },

                    //Noise
                    new Question() { Text = "Does noise matter in general?" },
                    new Question() { Text = "Do you listen to music loud?" },
                    new Question() { Text = "Do you value quiet in the house" },
                    new Question() { Text = "Will you be with playing musical instruments?" },

                    //Food
                    new Question() { Text = "Is a vegan or vegetarian diet important to you?" },
                    new Question() { Text = "Do you cook every day?" },
                    new Question() { Text = "Is keeping your own groceries separate important?" },
                    new Question() { Text = "Is eating with your housemates important?" },

                    //Animals
                    new Question() { Text = "Do you like animal companions?" },
                    new Question() { Text = "Will you mind caring for the housemate's animal companions, if they are absent?" },

                    //Friends
                    new Question() { Text = "Do you mind friends coming over?" },
                    new Question() { Text = "Do you mind friends or significant others staying overnight?" },
                    new Question() { Text = "Does hanging out with your housemates matter?" },

                    //Smoking
                    new Question() { Text = "Do you mind others smoking in the house?" },
                    new Question() { Text = "Do you mind others smoking weed in the house?" }
            };

                var roomies = context.Roomies.ToList();
                Random rnd = new Random();
                for (int i = 0; i < roomies.Count; i++)
                {
                    Test test = new Test()
                    {
                        Name = $"{roomies[i].FirstName} {roomies[i].LastName}",
                        Roomie = roomies[i],
                        Questions = new List<Question>()
                    };

                    foreach (var question in questions)
                    {
                        Question q = new Question();
                        q.Text = question.Text;
                        int n = rnd.Next(0, 3);
                        if (n == 2) q.Answer = "Yes";
                        else if (n == 1) q.Answer = "Maybe";
                        if (n == 0) q.Answer = "No";

                        q.Test = test;
                        test.Questions.Add(q);
                        context.Questions.AddOrUpdate(que => new { que.Id, que.TestId }, question);
                    }
                    roomies[i].HasTest = true;
                    context.Entry(roomies[i]).State = EntityState.Modified;
                    context.Tests.AddOrUpdate(t => t.TestId, test);
                    context.SaveChanges();

                }
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
