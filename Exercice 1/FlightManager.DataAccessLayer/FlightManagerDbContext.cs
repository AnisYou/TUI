using FlightManager.DataAccessLayer.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;

namespace FlightManager.DataAccessLayer
{
    public class FlightManagerDbContext : DbContext
    {
        public FlightManagerDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Airport>()
                .HasMany<Flight>(a => a.Arrivals)
                .WithOne(f => f.To)
                .HasForeignKey(a => a.ArrivalAirportId).Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Airport>()
                .HasMany<Flight>(a => a.Departures)
                .WithOne(f => f.From)
                .HasForeignKey(a => a.DepartureAirportId).Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Airline>()
              .HasMany<Flight>(a => a.Flights)
              .WithOne(f => f.FlightAirline)
              .HasForeignKey(a => a.AirlineId).Metadata.DeleteBehavior = DeleteBehavior.Restrict;


        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Airline> Airlines { get; set; }
    }
}
