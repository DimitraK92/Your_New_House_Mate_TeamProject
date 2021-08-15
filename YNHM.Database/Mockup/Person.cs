using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNHM.Database.Mockup
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string PhotoUrl { get; set; }
        public int MatchPercent { get; set; }
        public string Description { get; set; }


        public Person(int id, string firstName, string lastName, string photoUrl, string phone, string email, string facebook)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhotoUrl = photoUrl;
            Email = email;
            Facebook = facebook;
        }

        public Person(int id, string firstName, string lastName, int age, string photoUrl, int matchPercent,string description,string phone, string email, string facebook)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            PhotoUrl = photoUrl;
            MatchPercent = matchPercent;
            Description = description;
            Phone = phone;
            Email = email;
            Facebook = facebook;
        }
    }
}
