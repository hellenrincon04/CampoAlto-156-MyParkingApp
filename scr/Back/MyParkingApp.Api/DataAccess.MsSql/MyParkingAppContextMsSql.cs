using System.Configuration;
using Core.Entities;
using Core.Entities.Common;
using Data.Common.Implementation;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.MsSql
{
    public class MyParkingAppContextMsSql : UnitOfWork, IProjectManagerContext
    {

        public MyParkingAppContextMsSql(DbContextOptions options) : base(options)
        {
            //Database.EnsureCreated();
            //Database.EnsureCreated();
            //Database.Migrate();
        }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
             
            }

        }

        public virtual DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
