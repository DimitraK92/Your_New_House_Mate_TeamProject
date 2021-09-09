using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        [MinLength(2, ErrorMessage = "First name should have at least 2 characters.")]
        [MaxLength(15, ErrorMessage = "First name should have up to 15 characters")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MinLength(2, ErrorMessage = "Last Name should have at least 2 characters.")]
        [MaxLength(15, ErrorMessage = "Last name should have up to 15 characters")]
        public string LastName { get; set; }

        public int Age { get; set; }

        public string PhotoUrl { get; set; }

        [Display(Name = "Phone Number")]
        [StringLength(10, ErrorMessage = "Please enter a 10 digit phone number.", ErrorMessageResourceName = null, ErrorMessageResourceType = null, MinimumLength = 10)]
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