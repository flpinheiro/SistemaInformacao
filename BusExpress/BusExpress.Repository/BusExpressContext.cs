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
                u.HasKey(us => us.Id);
                u.HasAlternateKey(us => new { us.Latitude, us.Longitude })
                .HasName("Location");
            });

            modelBuilder.Entity<Company>(u =>
            {
                u.HasKey(us => us.Id);

            });

            modelBuilder.Entity<Bus>(u =>
            {
                u.HasKey(us => new { us.CompanyId, us.LicensePlate });
                u.HasOne(us => us.Company)
                .WithMany(us => us.Bus)
                .HasForeignKey(us => us.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<BusLine>(u =>
            {
                u.HasKey(us => us.Id);
                u.HasAlternateKey(us => new { us.Number, us.DotNumber });
            });

            modelBuilder.Entity<Card>(u =>
            {
                u.HasKey(us => us.UserId);
                u.HasOne(us => us.User)
                .WithOne(us => us.Card)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<BusStopLine>(u =>
            {
                u.HasKey(us => new { us.BusStopId, us.BusLineId });
                u.HasOne(us => us.BusLine)
                .WithMany(us => us.BusStopLine)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(us => us.BusLineId);
                u.HasOne(us => us.BusStop)
                .WithMany(us => us.BusStopLine)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(us => us.BusStopId);
            });

            modelBuilder.Entity<Route>(u =>
            {
                u.HasKey(us => us.Id);
                u.HasAlternateKey(us => new { us.UserId, us.Name });
                u.HasOne<BusStop>(us => us.StartPoint).WithMany("Route").HasForeignKey(us => us.StartPointId);
                u.HasOne<BusStop>(us => us.EndPoint).WithMany("Route").HasForeignKey(us => us.EndPointId);
            });

            modelBuilder.Entity<RouteLine>(u =>
            {
                u.HasKey(us => new { us.BusLineId, us.RouteId });
                u.HasOne(us => us.Route)
                .WithMany(us => us.RouteLine)
                .HasForeignKey(us => us.RouteId)
                .OnDelete(DeleteBehavior.Cascade);
                u.HasOne(us => us.BusLine)
                .WithMany(us => us.RouteLine)
                .HasForeignKey(us => us.BusLineId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<UserRote>(u =>
            {
                u.HasKey(us => new { us.UserId, us.RoutesId });
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
