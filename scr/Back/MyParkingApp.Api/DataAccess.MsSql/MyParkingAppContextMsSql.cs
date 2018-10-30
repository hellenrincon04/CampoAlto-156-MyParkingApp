using Core.Entities;
using Data.Common.Implementation;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.MsSql
{
    public class MyParkingAppContextMsSql : UnitOfWork, IProjectManagerContext
    {
        public MyParkingAppContextMsSql()
        {

            //Database.EnsureCreated();
            //Database.EnsureCreated();
            //Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["ProjectManagerString"].ConnectionString);
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
