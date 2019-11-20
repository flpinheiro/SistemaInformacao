using BusExpress.Model;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;

namespace BusExpress.Repository
{
    public class BusExpressContext : DbContext
    {
        public BusExpressContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<BusLine> BusLines { get; set; }
        public DbSet<BusStop> BusStops { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("BusExpress");

            modelBuilder.Entity<User>(u => 
            {
                u.HasKey(us => us.Id);            
            });

            modelBuilder.Entity<BusStop>(u => 
            {
                u.HasKey(us => new { us.Latitude, us.Longitude });
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

            modelBuilder.Entity<BusStopLine>(u => 
            {
                u.HasKey(us => new {us.BusLineId, us.BusStop});
            });

            modelBuilder.Entity<Route>(u => 
            {
                u.HasKey(us => new {us.UserId, us.Name });
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
