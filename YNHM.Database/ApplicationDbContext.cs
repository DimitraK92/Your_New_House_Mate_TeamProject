using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using YNHM.Entities.Models;
using YNHM.Entities.TestResources;

namespace YNHM.Database
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Roomie> Roomies { get; set; }
        public DbSet<RoomiesPair> RoomiesPair { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }

        public ApplicationDbContext() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HouseMate;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}
