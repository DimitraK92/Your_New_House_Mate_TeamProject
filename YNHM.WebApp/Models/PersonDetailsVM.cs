using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YNHM.WebApp.Models
{
    public class PersonDetailsVM
    {

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }

        public string Description { get; set; }

        public string PhotoUrl { get; set; }
    
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Display(Name = "Facebook Profile")]
        public string Facebook { get; set; }

        public string Instagram { get; set; }
        public string Twitter { get; set; }
    }


}