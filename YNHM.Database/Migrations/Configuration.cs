namespace YNHM.Database.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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
                string[] firstNames =   { 
                    "Maria", "Mohammed", "Wei", "Yan", "John",
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
                    "Nienor","Luthien","Saruman"
                };

                string[] lastNames =    {
                    "Wang","Nagata","Holden","Burton","Kamal",
                    "Dawes","Anderson","Avasarala","Inaros", "Mao",
                    "Johnson","Miller","Wei","Volovodof","Shaddid",
                    "Drummer","Ashford","Cortazar","Errinwright","Murtry",
                    "Pereira","Ren","Skywalker","Lannister","Stark",
                    "Baratheon","Martell","Targaryen","Arryn","Tyrell",
                    "Tully","Greyjoy","Allgood","Allyrion","Amber",
                    "Bolton","Blount","Bar Emmon","Celtigar","Velaryon",
                    "Sunglass","Brune","Blackfyre","Slynt","Mormont","Cerwyn"
                };


                string[] photoUrls =
                {
                    "https://images.generated.photos/By5wHa-A399_axM6a3LK0Fh0dvtB8YTjC_GzPnKLF8A/rs:fit:256:256/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/MTkxMjgwLmpwZw.jpg",
                    "https://images.generated.photos/idBs6cTp1oeByLZ8uOnWN_X4WCXuaMXTdL-hn7nT0zY/rs:fit:256:256/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/ODY0MTkxLmpwZw.jpg",
                    "https://images.generated.photos/bPnqE37aUUPsB0SSOw9U0na0l31H0o0rDqSPKzymy9s/rs:fit:256:256/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/MzE0MjUyLmpwZw.jpg",
                    "https://images.generated.photos/3y-hCTGgXQW05YcuipKr3GYe9WWqG7L8_jbbkIu2TwU/rs:fit:256:256/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/ODg5Njc3LmpwZw.jpg",
                    "https://images.generated.photos/NWLOPSC2kc3No9PP625tjeS10zSTEwPsD1_QpXpHXmk/rs:fit:256:256/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/MDA3MDIwLmpwZw.jpg",
                    "https://images.generated.photos/_YTseQf3MZfU6-zTRfKTd_sWP5nyscyvIOo_Wh-GHCo/rs:fit:256:256/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/NDE2MDA0LmpwZw.jpg",
                    "https://images.generated.photos/8IbsJ6feXtsZm7GspT65FPCkRenuqdtz4-aUvXOcEkM/rs:fit:256:256/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/ODE3NzYwLmpwZw.jpg",
                    "https://images.generated.photos/LVzqTLaB5YMec4iyz3V7L7QrjXZ1ZTSqMr7ND_coipA/rs:fit:256:256/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/NzAyNDU0LmpwZw.jpg",
                    "https://images.generated.photos/siVcC4O7_ZZ481xreVc8ORSt0qriBNpZ8QTlqRJI6Xw/rs:fit:256:256/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/NjgxNzA2LmpwZw.jpg",
                    "https://images.generated.photos/qn1dKX9V-S50sEXeHC09OUcwK3v60EaxhVWiY44O6vU/rs:fit:256:256/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/NjQwNzE2LmpwZw.jpg",
                    "https://images.generated.photos/H7My5xi7BPGkwA1IdoVDeN7sRYJNk2p-htIQsRpUjlY/rs:fit:256:256/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/MTM2NDUyLmpwZw.jpg",
                    "https://images.generated.photos/gw2L-1476wYRIis7FJFnv7E133fbxyNp8tkdfCBiIpM/rs:fit:256:256/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/NTUzMTE1LmpwZw.jpg",
                    "https://images.generated.photos/zkLaESK97b5cwiJq4zZpSmm549UQwFcAiHi_dMzh4ng/rs:fit:256:256/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/ODk4MjM0LmpwZw.jpg"

                };

                Random rand = new Random();
                for (int i = 0; i < 100; i++)
                {
                    string firstName = firstNames[rand.Next(0, firstNames.Length)];
                    string lastName = lastNames[rand.Next(0, lastNames.Length)];
                    string photoUrl = photoUrls[rand.Next(0, photoUrls.Length)];
                    string email = $"{firstName}.{lastName}@gmail.com";
                    string phone = $"69{rand.Next(11111111, 100000000)}";
                    int age = rand.Next(18, 101);
                    bool subscribed= false;
                    if (rand.Next(0,101)%3==0)
                    {
                        subscribed = true;
                    }

                    Roomie r = new Roomie()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        Phone = phone,
                        Email = email,
                        IsMatched = false,
                        HasHouse = false,
                        IsSubscribed = subscribed,
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
                    IsSubscribed = true,
                };
                Roomie r2 = new Roomie()
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Age = 36,
                    PhotoUrl = "https://images.generated.photos/JKjKOvFLNOPUqQ2L2I8JnXPB-A87WW6xKU0bjItSna8/rs:fit:256:256/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/MDQxODk4LmpwZw.jpg",
                    Phone = "0306900000000",
                    Email = @"janedoe@gmail.com",
                    Facebook = @"https://www.facebook.com/janedoe/",

                };
                Roomie r3 = new Roomie()
                {
                    FirstName = "Jim",
                    LastName = "Do",
                    Age = 10,
                    PhotoUrl = "https://images.generated.photos/56htaLQXIIqPG9SC9cUTnA0LtEQV0W6sdUFsO7VbsLg/rs:fit:256:256/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/NTQ1MTAwLmpwZw.jpg",
                    Phone = "0306900000000",
                    Email = @"jimdo@gmail.com",
                    Facebook = @"https://www.facebook.com/jimdo/",

                };
                Roomie r4 = new Roomie()
                {
                    FirstName = "Max",
                    LastName = "Dont",
                    Age = 48,
                    PhotoUrl = "https://images.generated.photos/kYj2SDvgnF7u42kKZ6mYgSLR2jwbMMRdIjWOf33wRPo/rs:fit:256:256/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/NjU0MjQ3LmpwZw.jpg",
                    Phone = "0306900000000",
                    Email = @"maxdont@gmail.com",
                    Facebook = @"https://www.facebook.com/maxdont/",
                    
                };
                Roomie r5 = new Roomie()
                {
                    FirstName = "Min",
                    LastName = "Donot",
                    Age = 82,
                    PhotoUrl = "https://images.generated.photos/oCB4g5L1MJ8oLTZue9YT53Zcox2fL7S8sIQ6IHd4018/rs:fit:256:256/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/OTYwMDc3LmpwZw.jpg",
                    Phone = "0306900000000",
                    Email = @"mindonot@gmail.com",
                    Facebook = @"https://www.facebook.com/mindonot/",
                };
                Roomie r6 = new Roomie()
                {
                    FirstName = "Jill",
                    LastName = "Cannot",
                    Age = 30,
                    PhotoUrl = "https://images.generated.photos/h39VCpy-2v2WDYzyqT-8LcTJZeJ0YysbXm6-IHqHov8/rs:fit:256:256/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/NjUwMjA4LmpwZw.jpg",
                    Phone = "0306900000000",
                    Email = @"jillcannot@gmail.com",
                    Facebook = @"https://www.facebook.com/jillcannot/",
                };
                Roomie r7 = new Roomie()
                {
                    FirstName = "Jake",
                    LastName = "Shallnot",
                    Age = 63,
                    PhotoUrl = "https://images.generated.photos/ZXEmTeIdKBps5TSRxltdHAI6uU3S6c322VrwiAdq7Uw/rs:fit:256:256/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/MzY1OTM4LmpwZw.jpg",
                    Phone = "0306900000000",
                    Email = @"jakeshallnot@gmail.com",
                    Facebook = @"https://www.facebook.com/jakeshallnot/",
                };
                Roomie r8 = new Roomie()
                {
                    FirstName = "Bill",
                    LastName = "Shall",
                    Age = 27,
                    PhotoUrl = "https://images.generated.photos/W7_ZGDX7l51Gilm6hXEES390JBJeOmcpWc1NnBqU0xM/rs:fit:256:256/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/MTAwNDUwLmpwZw.jpg",
                    Phone = "0306900000000",
                    Email = @"billshall@gmail.com",
                    Facebook = @"https://www.facebook.com/billshall/",
                };
                Roomie r9 = new Roomie()
                {
                    FirstName = "Andy",
                    LastName = "Can",
                    Age = 51,
                    PhotoUrl = "https://images.generated.photos/rpJaN9W1m_Oa_jrfD-tm9W-Febt9hWFA-FxhgIz085c/rs:fit:256:256/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/MzU5MTEyLmpwZw.jpg",
                    Phone = "0306900000000",
                    Email = @"andycan@gmail.com",
                    Facebook = @"https://www.facebook.com/andycan/",
                };
                Roomie r10 = new Roomie()
                {
                    FirstName = "Andria",
                    LastName = "Could",
                    Age = 18,
                    PhotoUrl = "https://images.generated.photos/werTYBNwM1Y1Y4HI1lHw4C2k66NlS--Lyr9V_U1yApM/rs:fit:256:256/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/NzEyMjA2LmpwZw.jpg",
                    Phone = "0306900000000",
                    Email = @"andriacould@gmail.com",
                    Facebook = @"https://www.facebook.com/andriacould/",

                };
                Roomie r11 = new Roomie()
                {
                    FirstName = "Maria",
                    LastName = "Couldnot",
                    Age = 36,
                    PhotoUrl = "https://images.generated.photos/9xUs4FjOxVTJS8FFIm9GPBdWkjYunDDqJhUPFa50Nxc/rs:fit:256:256/czM6Ly9pY29uczgu/Z3Bob3Rvcy1wcm9k/LnBob3Rvcy92M18w/NTM0MzExLmpwZw.jpg",
                    Phone = "0306900000000",
                    Email = @"mariacouldnot@gmail.com",
                    Facebook = @"https://www.facebook.com/mariacouldnot/",
                };
                Roomie r12 = new Roomie()
                {
                    FirstName = "Dimitra",
                    LastName = "Kamni",
                    Age = 28,
                    Email = "dimitra.kam@gmail.com",
                    Phone = "6945123456",
                    IsSubscribed = true

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


                CreateRolesAndUsers();
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

        /// <summary>
        /// Creates Roles, if they do not exist. Creates Admin users.
        /// </summary>
        private void CreateRolesAndUsers()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            //Admin Role and User is added
            if (!roleManager.RoleExists("Admin"))
            {
                var admin = new IdentityRole()
                {
                    Name = "Admin"
                };

                roleManager.Create(admin);

                //TODO: VASSILIS: Change admin pass and add more admins
                int roomieId = 1;

                #region VassilisK
                if (db.Roomies.Count() != 0)
                {
                    roomieId = db.Roomies.Where(r => r.LastName == "Kotsmanidis").Select(r => r.Id).FirstOrDefault();
                }
                var userAdmin = new ApplicationUser()
                {
                    UserName = "VassilisK",
                    Email = "vassilis.kotsman@gmail.com",
                    RoomieId = roomieId,
                    IsSubscribed = true,
                    SubscriptionStarts = DateTime.Now,
                    SubscriptionExpires = DateTime.Now.AddYears(5)
                };
                string adminPassword = "Admin123!";

                var userCreated = userManager.Create(userAdmin, adminPassword);

                if (userCreated.Succeeded)
                {
                    userManager.AddToRole(userAdmin.Id, "Admin");
                }
                #endregion

                #region DimitraK
                if (db.Roomies.Count() != 0)
                {
                    roomieId = db.Roomies.Where(r => r.LastName == "Kamni").Select(r => r.Id).FirstOrDefault();
                }
                var dimitraAdmin = new ApplicationUser()
                {
                    UserName = "DimitraK",
                    Email = "dimitra.kam@gmail.com",
                    RoomieId = roomieId,
                    IsSubscribed = true,
                    SubscriptionStarts = DateTime.Now,
                    SubscriptionExpires = DateTime.Now.AddYears(5)
                };

                userCreated = userManager.Create(dimitraAdmin, adminPassword);
                if (userCreated.Succeeded)
                {
                    userManager.AddToRole(dimitraAdmin.Id, "Admin");
                }
                #endregion
            }

            if (!roleManager.RoleExists("Roomie"))
            {
                var roomie = new IdentityRole()
                {
                    Name = "Roomie"
                };

                roleManager.Create(roomie);
            }

            if (!roleManager.RoleExists("Subscriber"))
            {
                var subscriber = new IdentityRole()
                {
                    Name = "Subscriber"
                };
                roleManager.Create(subscriber);
            }
        }

    }
}
