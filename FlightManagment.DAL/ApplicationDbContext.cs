using FlightManagment.DAL.Configurations.Entities;
using FlightManagment.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightManagment.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountrySeed());
            modelBuilder.ApplyConfiguration(new AirportSeed());
        }
        
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Flight> Flights { get; set; }
    }
}