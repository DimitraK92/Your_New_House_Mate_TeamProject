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
                int roomieId = 1;

                #region VassilisK
                if (db.Roomies.Count()!=0)
                {
                    roomieId = db.Roomies.Where(r => r.LastName == "Kotsmanidis").Select(r => r.Id).FirstOrDefault();
                }
                var userAdmin = new ApplicationUser()
                {
                    UserName = "VassilisK",
                    Email = "vassilis.kotsman@gmail.com",
                    RoomieId = roomieId
                };
                string adminPassword = "Admin123!";

                var userCreated = userManager.Create(userAdmin, adminPassword);

                if (userCreated.Succeeded)
                {
                    userManager.AddToRole(userAdmin.Id, "Admin");
                }
                #endregion

                #region DimitraK
                if (db.Roomies.Count() != 0)
                {
                    roomieId = db.Roomies.Where(r => r.LastName == "Kamni").Select(r => r.Id).FirstOrDefault();
                }
                var dimitraAdmin = new ApplicationUser()
                {
                    UserName = "DimitraK",
                    Email = "dimitra.kam@gmail.com",
                    RoomieId = roomieId
                };

                userCreated = userManager.Create(dimitraAdmin, adminPassword);
                if (userCreated.Succeeded)
                {
                    userManager.AddToRole(dimitraAdmin.Id, "Admin" );
                }
                #endregion
            }

            if (!roleManager.RoleExists("Roomie"))
            {
                var roomie = new IdentityRole()
                {
                    Name = "Roomie"
                };

                roleManager.Create(roomie);
            }

        }

    }
}
