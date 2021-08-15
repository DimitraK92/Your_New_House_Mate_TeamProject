using System;
using System.Data.Entity;
using System.Linq;
using YNHM.Database.Models;
using YNHM.Database.Models.Base;

namespace YNHM.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public ApplicationDbContext() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ONOMA;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }
        public ApplicationDbContext(string connectionString= "ONOMA") : base(connectionString)
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }

        public override int SaveChanges()
        {
            this.ChangeTracker.DetectChanges();
            var changed = this.ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Added || t.State == EntityState.Modified)
                        .ToList();

            foreach (var entry in changed)
            {
                if (entry.Entity is BaseModel)
                {
                    var track = entry.Entity as BaseModel;
                    if (entry.State == EntityState.Added)
                    {
                        track.CreationDate = DateTime.UtcNow;
                        track.UpdateDate = DateTime.UtcNow;
                    }
                    else
                    {
                        track.UpdateDate = DateTime.UtcNow;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
