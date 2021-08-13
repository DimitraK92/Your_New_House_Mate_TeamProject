using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNHM.Database.Mockup
{
    public class MockupDb
    {
        public List<Person> MockupPeople { get; set; } = new List<Person>()
        {
            new Person(1,"Jane","Doe",36,"https://thispersondoesnotexist.com/",95,"I will say that I am a good person, of course, but I am shit.","6946666666","user.email@gmail.com","https://el-gr.facebook.com/generic-user-name"),
            new Person(2,"Jim","Do",40,"https://thispersondoesnotexist.com/",89,"I will say that I am a good person, of course, but I am shit.","6946666666","user.email@gmail.com","https://el-gr.facebook.com/generic-user-name"),
            new Person(3,"Max","Dont",25,"https://thispersondoesnotexist.com/",56,"I will say that I am a good person, of course, but I am shit.","6946666666","user.email@gmail.com","https://el-gr.facebook.com/generic-user-name"),
            new Person(4,"Min","Donot",21,"https://thispersondoesnotexist.com/",54,"I will say that I am a good person, of course, but I am shit.","6946666666","user.email@gmail.com","https://el-gr.facebook.com/generic-user-name"),
            new Person(5,"Jill","Cannot",27,"https://thispersondoesnotexist.com/",87,"I will say that I am a good person, of course, but I am shit.","6946666666","user.email@gmail.com","https://el-gr.facebook.com/generic-user-name"),
            new Person(6,"Jake","Shallnot",87,"https://thispersondoesnotexist.com/",42,"I will say that I am a good person, of course, but I am shit.","6946666666","user.email@gmail.com","https://el-gr.facebook.com/generic-user-name"),
            new Person(7,"Bill","Shall",52,"https://thispersondoesnotexist.com/",95,"I will say that I am a good person, of course, but I am shit.","6946666666","user.email@gmail.com","https://el-gr.facebook.com/generic-user-name"),
            new Person(8,"Andy","Can",65,"https://thispersondoesnotexist.com/",77,"I will say that I am a good person, of course, but I am shit.","6946666666","user.email@gmail.com","https://el-gr.facebook.com/generic-user-name"),
            new Person(9,"Andria","Could",44,"https://thispersondoesnotexist.com/",64,"I will say that I am a good person, of course, but I am shit.","6946666666","user.email@gmail.com","https://el-gr.facebook.com/generic-user-name"),
            new Person(10,"Maria","Couldnot",43,"https://thispersondoesnotexist.com/",32,"I will say that I am a good person, of course, but I am shit.","6946666666","user.email@gmail.com","https://el-gr.facebook.com/generic-user-name")
        };



    }
}
