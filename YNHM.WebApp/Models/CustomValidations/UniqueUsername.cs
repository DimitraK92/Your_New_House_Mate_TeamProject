using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using YNHM.Database;
using YNHM.RepositoryServices;

namespace YNHM.WebApp.Models.CustomValidations
{
    public class UniqueUsername : ValidationAttribute
    {
        //TODO: VASSILIS: Fix "The function evaluation requires all threads to run"
        ApplicationDbContext db = new ApplicationDbContext();

        public override bool IsValid(object value)
        {
            //return ur.CheckIfExists(value as string);
            return db.Users.Select(u => u.UserName).ToList().Contains(value as string);
        }

        public override string FormatErrorMessage(string name)
        {
            return $"This {name} already exists! Please choose another.";
        }

    }
}