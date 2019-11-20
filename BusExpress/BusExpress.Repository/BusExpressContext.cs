using BusExpress.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace BusExpress.Repository
{
    public class BusExpressContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BusLine> BusLines { get; set; }
        public DbSet<BusStop> BusStops { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(u => 
            {
                u.HasKey(us => us.Id);            
            });

            modelBuilder.Entity<BusStop>(u => 
            {
                u.HasKey(us => new { us.Location.Latitude, us.Location.Longitude });
            });

            modelBuilder.Entity<Company>(u => 
            {
                u.HasKey(us=> us.Id);
            });

            modelBuilder.Entity<Bus>(u=> 
            {
                u.HasKey( us => new {us.CompanyId, us.LicensePlate });
            });

            modelBuilder.Entity<BusLine>(u => 
            {
                u.HasKey(us => new {us.Name, us.DotNumber });
            });

            modelBuilder.Entity<Card>(u => 
            {
                u.HasKey(us => us.UserId);
            });


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
