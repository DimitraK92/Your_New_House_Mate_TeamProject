using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using YNHM.Entities.Models;

namespace YNHM.WebApp.Models
{
    public class PersonDetailsVM
    {
        public Roomie Roomie { get; set; }

        public PersonDetailsVM(Roomie roomie)
        {
            Roomie = roomie;
        }


        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public int Age { get; set; }

        public string PhotoUrl { get; set; }

        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Display(Name = "Facebook Profile")]
        public string Facebook { get; set; }

        public string GetUsersName()
        {
            return $"{Roomie.FirstName} {Roomie.LastName}";
        }
    }
}