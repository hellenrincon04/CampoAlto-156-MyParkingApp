using System.Configuration;
using Core.Entities;
using Data.Common.Implementation;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.MySql
{
    public class MyParkingAppContextMySql : UnitOfWork, IProjectManagerContext
    {

        public MyParkingAppContextMySql()
        {

            //Database.EnsureCreated();
            //Database.EnsureCreated();
            //Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(ConfigurationManager.ConnectionStrings["MyParkingAppMySql"].ConnectionString);
            }

        }

        public virtual DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.Property(e => e.UserId).IsRequired();
            //});

            //modelBuilder.Entity<Post>(entity =>
            //{
            //    entity.HasOne(d => d.Blog)
            //        .WithMany(p => p.Post)
            //        .HasForeignKey(d => d.BlogId);
            //});
        }
    }
}
