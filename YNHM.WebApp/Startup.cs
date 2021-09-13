using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Linq;
using YNHM.Database;
using YNHM.Entities.Models;

[assembly: OwinStartupAttribute(typeof(YNHM.WebApp.Startup))]
namespace YNHM.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }




    }
}
