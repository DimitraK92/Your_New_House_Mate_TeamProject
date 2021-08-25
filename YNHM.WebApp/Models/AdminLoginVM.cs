using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YNHM.WebApp.Models
{
    public class AdminLoginVM
    {

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }




    }
}