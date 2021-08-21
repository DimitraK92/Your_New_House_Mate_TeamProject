using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using YNHM.Database;

namespace YNHM.WebApp.Models.CustomValidations
{
    public class UniqueUsername : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                if (ctx.Users.Select(x => x.UserName).Contains(value as string))
                    return false;
            }


            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"This username already exists! Please choose another.";
        }

    }
}