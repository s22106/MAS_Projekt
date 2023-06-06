using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Enum
{
    public class MASDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<CompartmentWagon> CompartmentWagons { get; set; }
        public DbSet<Conductor> Conductors { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LinkStations> LinkStations { get; set; }
        public DbSet<OpenWagon> OpenWagons { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<RailLink> RailLinks { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<TrainStation> TrainStations { get; set; }
        public DbSet<Transit> Transits { get; set; }
        public DbSet<Wagon> Wagons { get; set; }

        public MASDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(builder =>
            {
                builder.HasKey(c => c.CityId);
                builder.Property(c => c.Name).IsRequired();
                builder.HasData(new City
                {
                    CityId = 1,
                    Name = "Warszawa"
                });
            });
            modelBuilder.Entity<TrainStation>(builder =>
            {
                builder.HasKey(ts => ts.StationId);
                builder.Property(ts => ts.NumbrOfPlatforms).IsRequired();
                builder.Property(ts => ts.NumbrOfTracks).IsRequired();
                builder.HasOne(ts => ts.City).WithMany(c => c.TrainStations).HasForeignKey(ts => ts.CityId);
                builder.HasData(new TrainStation
                {
                    StationId = 1,
                    CityId = 1,
                    NumbrOfPlatforms = 5,
                    NumbrOfTracks = 10,
                    Name = "Warszawa Centralna",
                    StationType = StationType.StartStation
                });
            });
        }
    }
}