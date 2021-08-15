using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNHM.Database.Mockup
{
    public class MockupDb
    {
        private static List<string> PhotoUrls = new List<string>()
        {
            "https://i.pinimg.com/originals/05/96/1e/05961e1ce9e6492a11292042263c44de.jpg",
            "http://cdn.home-designing.com/wp-content/uploads/2014/10/simple-small-bedroom.jpeg",
            "https://cdn.decoratorist.com/wp-content/uploads/design-house-interior-contemporary-living-room-367286.jpg",
            "https://hative.com/wp-content/uploads/2013/05/white-small-bathroom-decorating-layout-2502.jpg",
            "https://i.pinimg.com/originals/59/05/a4/5905a473f3cc38b72e79a5ee2bc40705.jpg",
            "https://i.pinimg.com/originals/4d/19/59/4d195933bb3df785114a7af88b02fdf1.jpg"
        };

        private static Person HouseManager = new Person(11, "Gianna", "Mesitria", "~/Models/FakeImages/person1.jpg",
                                                        "694 656 6566", "gianna.mesitria@gmail.com", "https://el-gr.facebook.com/generic-user-name");

        private static string[] Districts =
        {
            "City Center",
            "North",
            "South",
            "East",
            "West"
        };


        public List<Person> MockupPeople { get; set; } = new List<Person>()
        {
            new Person(1,"Jane","Doe",36,"https://thispersondoesnotexist.com/",95,"I will say that I am a good person, of course, but I am shit.","694 666 6666","user.email@gmail.com","https://el-gr.facebook.com/generic-user-name"),
            new Person(2,"Jim","Do",40,"https://thispersondoesnotexist.com/",89,"I will say that I am a good person, of course, but I am shit.","694 666 6666","user.email@gmail.com","https://el-gr.facebook.com/generic-user-name"),
            new Person(3,"Max","Dont",25,"https://thispersondoesnotexist.com/",56,"I will say that I am a good person, of course, but I am shit.","694 666 6666","user.email@gmail.com","https://el-gr.facebook.com/generic-user-name"),
            new Person(4,"Min","Donot",21,"https://thispersondoesnotexist.com/",54,"I will say that I am a good person, of course, but I am shit.","694 666 6666","user.email@gmail.com","https://el-gr.facebook.com/generic-user-name"),
            new Person(5,"Jill","Cannot",27,"https://thispersondoesnotexist.com/",87,"I will say that I am a good person, of course, but I am shit.","694 666 6666","user.email@gmail.com","https://el-gr.facebook.com/generic-user-name"),
            new Person(6,"Jake","Shallnot",87,"https://thispersondoesnotexist.com/",42,"I will say that I am a good person, of course, but I am shit.","694 666 6666","user.email@gmail.com","https://el-gr.facebook.com/generic-user-name"),
            new Person(7,"Bill","Shall",52,"https://thispersondoesnotexist.com/",95,"I will say that I am a good person, of course, but I am shit.","694 666 6666","user.email@gmail.com","https://el-gr.facebook.com/generic-user-name"),
            new Person(8,"Andy","Can",65,"https://thispersondoesnotexist.com/",77,"I will say that I am a good person, of course, but I am shit.","694 666 6666","user.email@gmail.com","https://el-gr.facebook.com/generic-user-name"),
            new Person(9,"Andria","Could",44,"https://thispersondoesnotexist.com/",64,"I will say that I am a good person, of course, but I am shit.","694 666 6666","user.email@gmail.com","https://el-gr.facebook.com/generic-user-name"),
            new Person(10,"Maria","Couldnot",43,"https://thispersondoesnotexist.com/",32,"I will say that I am a good person, of course, but I am shit.","694 666 6666","user.email@gmail.com","https://el-gr.facebook.com/generic-user-name")
        };

        public List<House> MockupHouses { get; set; } = new List<House>
        {
            new House(1, "Ugly exterior with surprising interior", "Fokionos Negri 45", "11361", 60, 2, 2, 300, PhotoUrls, Districts[0],"https://goo.gl/maps/2LMwmuBWZW5SvDEe6",HouseManager),
            new House(2, "Ugly exterior with surprising interior", "Kypselis 32","12541",75, 3, 4, 450, PhotoUrls, Districts[0],"https://goo.gl/maps/2LMwmuBWZW5SvDEe6",HouseManager),
            new House(3, "Ugly exterior with surprising interior", "Frynis 56","13341",50, 1, 2, 250, PhotoUrls, Districts[0],"https://goo.gl/maps/2LMwmuBWZW5SvDEe6",HouseManager),
            new House(4, "Ugly exterior with surprising interior", "Patision 165","11322", 105, 5, 3, 500, PhotoUrls, Districts[0],"https://goo.gl/maps/2LMwmuBWZW5SvDEe6",HouseManager),
            new House(5, "Ugly exterior with surprising interior", "Kerkyras 98","16376", 84, 2, 4, 405, PhotoUrls, Districts[0],"https://goo.gl/maps/2LMwmuBWZW5SvDEe6",HouseManager),
            new House(6, "Ugly exterior with surprising interior", "Naxou 134","13334", 93, 3, 3, 365, PhotoUrls, Districts[0],"https://goo.gl/maps/2LMwmuBWZW5SvDEe6",HouseManager),
            new House(7, "Ugly exterior with surprising interior", "Themistokleous 87","15331", 102, 6, 3, 420, PhotoUrls, Districts[0],"https://goo.gl/maps/2LMwmuBWZW5SvDEe6",HouseManager),
            new House(8, "Ugly exterior with surprising interior", "Kallidromiou 60","13341", 200, 5, 4,740, PhotoUrls, Districts[0],"https://goo.gl/maps/2LMwmuBWZW5SvDEe6",HouseManager),
            new House(9, "Ugly exterior with surprising interior", "Voulgaroktonou 1", "11363",45, 0, 2, 250, PhotoUrls, Districts[0],"https://goo.gl/maps/2LMwmuBWZW5SvDEe6",HouseManager),
            new House(10, "Ugly exterior with surprising interior", "Agias Zonis 27", "11354",65, 3, 3, 365, PhotoUrls, Districts[0],"https://goo.gl/maps/2LMwmuBWZW5SvDEe6",HouseManager),
        };



    }
}
