using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShowPlanner.Domain;
using System;

namespace ShowPlanner.DAL.Entity
{
    public class ShowPlannerDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Show> Shows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
