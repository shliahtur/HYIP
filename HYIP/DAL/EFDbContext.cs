using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using HYIP.Models;

namespace HYIP.DAL
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("HyipDb")
        {
        }
        public static EFDbContext Create()
        {
            return new EFDbContext();
        }
       
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer<EFDbContext>(null);
            base.OnModelCreating(modelBuilder);

        }
    }
}