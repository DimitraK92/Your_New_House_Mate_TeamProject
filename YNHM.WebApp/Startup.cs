using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using YNHM.Database;
using YNHM.Database.Models;

[assembly: OwinStartupAttribute(typeof(YNHM.WebApp.Startup))]
namespace YNHM.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }


        /// <summary>
        /// Creates Roles, if they do not exist. Creates Admin user.
        /// </summary>
        private void CreateRolesAndUsers()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            //Admin Role and User is added
            if (!roleManager.RoleExists("Admin"))
            {
                var admin = new IdentityRole()
                {
                    Name = "Admin"
                };

                roleManager.Create(admin);

                //TODO: VASSILIS: Change admin pass and add more admins
                var userAdmin = new ApplicationUser()
                {
                    UserName = "VassilisK",
                    Email = "vassilis.kotsman@gmail.com",
                };
                string adminPassword = "Admin123!";

                var userCreated = userManager.Create(userAdmin, adminPassword);

                if (userCreated.Succeeded)
                {
                    userManager.AddToRole(userAdmin.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("HouseSeeker"))
            {
                var houseSeeker = new IdentityRole()
                {
                    Name = "HouseSeeker"
                };

                roleManager.Create(houseSeeker);
            }

            if (!roleManager.RoleExists("HouseManager"))
            {
                var houseManager = new IdentityRole()
                {
                    Name = "HouseManager"
                };

                roleManager.Create(houseManager);
            }

        }

    }
}
