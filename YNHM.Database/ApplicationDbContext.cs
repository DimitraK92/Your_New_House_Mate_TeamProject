﻿using System;
using System.Data.Entity;
using System.Linq;
using YNHM.Database.Models;

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
    }
}
