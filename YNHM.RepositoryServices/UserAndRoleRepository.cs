using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using YNHM.Database;

namespace YNHM.RepositoryServices
{
    public class UserAndRoleRepository
    {
        readonly ApplicationDbContext db = new ApplicationDbContext();
        public bool CheckIfUserExists(string userName)
        {
            return db.Users.Select(u => u.UserName).ToList().Contains(userName) ? true : false;
        }

        public ICollection<IdentityRole> AllRoles()
        {
            return db.Roles.ToList();
        }

        public IdentityRole FindRoleByName(string roleName)
        {
            return db.Roles.First(r => r.Name == roleName);
        }
        public ICollection<IdentityUser> GetAllUsers()
        {
            return db.Users.ToList();
        }

        public IdentityUser FindUserByUsername(string userName)
        {
            return db.Users.First(u => u.UserName == userName);
        }

        public IdentityUser FindUserByEmail(string email)
        {
            return db.Users.First(u => u.Email == email);
        }

        public ICollection<IdentityUser> GetUsersByRole(string roleName)
        {
            var roleId = FindRoleByName(roleName).Id;
            return db.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains(roleId)).ToList();
        }
        public string GetUserRole(IdentityUser user)
        {
            var userRoles = user.Roles as List<string>;
            if (userRoles.Contains("Admin"))
            {
                return "Administrator";
            }
            else
            {
                return userRoles.FirstOrDefault();
            }

        }

    }
}
