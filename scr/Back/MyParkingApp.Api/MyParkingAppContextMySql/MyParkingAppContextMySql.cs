using Core.Entities;
using Data.Common.Implementation;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.MySql
{
    public class MyParkingAppContextMySql : UnitOfWork, IProjectManagerContext
    {
        public MyParkingAppContextMySql(DbContextOptions options) : base(options)
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
