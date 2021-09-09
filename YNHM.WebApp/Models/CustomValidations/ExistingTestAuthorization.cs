using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YNHM.Database;

namespace YNHM.WebApp.Models.CustomValidations
{
    public class ExistingTestAuthorization :AuthorizeAttribute
    {
        ApplicationDbContext db = new ApplicationDbContext();

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = db.Users.Where(m => m.UserName == httpContext.User.Identity.Name);
            return base.AuthorizeCore(httpContext);
        }




    }
}