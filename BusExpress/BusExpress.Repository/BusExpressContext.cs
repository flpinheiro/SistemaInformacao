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
                u.HasOne(us => us.BusStopLine)
                .WithMany(us => us.BusStop)
                .HasForeignKey(us => us.Id);
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
                u.HasKey(us => new { us.Number, us.DotNumber });
                u.HasOne(us => us.BusStopLine)
                .WithMany(us => us.BusLine)
                .HasForeignKey(us => new { us.Number, us.DotNumber })
                .OnDelete(DeleteBehavior.Cascade);
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
                u.HasKey(us => new { us.BusStopId, us.Number, us.DotNumber });
                //u.HasMany(us => us.)
                //u.HasOne(us => us.BusLine)
                //.WithMany(us => us.BusStopLine)
                //.HasForeignKey(us => new {us.Number, us.DotNumber })
                //.OnDelete(DeleteBehavior.Cascade);
                //u.HasOne(us => us.BusStop)
                //.WithMany(us => us.BusStopLine)
                //.HasForeignKey(us => us.BusStopId)
                //.OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Route>(u =>
            {
                u.HasKey(us => new { us.UserId, us.Name });
                u.HasOne(us => us.StartPoint)
                .WithMany()
                .HasForeignKey(us => us.StartPointId)
                .OnDelete(DeleteBehavior.NoAction);
                u.HasOne(us => us.EndPoint)
                .WithMany()
                .HasForeignKey(us => us.EndPointId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<UserRote>(u => 
            {
                u.HasKey(us => new {us.UserId, us.RoutesId });
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
