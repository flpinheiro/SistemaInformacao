using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusExpress.Repository
{
    public class BusExpressContextFactory : IDesignTimeDbContextFactory<BusExpressContext>
    {
        private static string _connectionString;

        public BusExpressContext CreateDbContext()
        {
            return CreateDbContext(null);
        }

        public BusExpressContext CreateDbContext(string[] args)
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                LoadConnectionString();
            }
            var builder = new DbContextOptionsBuilder<BusExpressContext>();
            builder.UseSqlServer(_connectionString);

            return new BusExpressContext(builder.Options);
        }

        private static void LoadConnectionString()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile(
                "appsettings.json", optional: false);

            var configuration = builder.Build();

            _connectionString = configuration.GetConnectionString("Default");
        }
    }
}