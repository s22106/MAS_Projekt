using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Npgsql;

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
            NpgsqlConnection.GlobalTypeMapper.MapEnum<StationType>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<OpenWagonType>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<SeatType>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<StationType>();
            modelBuilder.HasPostgresEnum<OpenWagonType>();
            modelBuilder.HasPostgresEnum<SeatType>();

            modelBuilder.Entity<City>(builder =>
            {
                builder.HasKey(e => e.CityId);
                builder.Property(e => e.Name).IsRequired();
                builder.HasData(new City
                {
                    CityId = 1,
                    Name = "Warszawa"
                });
            });
            modelBuilder.Entity<TrainStation>(builder =>
            {
                builder.HasKey(e => e.StationId);
                builder.Property(e => e.NumbrOfPlatforms).IsRequired();
                builder.Property(e => e.NumbrOfTracks).IsRequired();
                builder.HasOne(e => e.City).WithMany(e => e.TrainStations).HasForeignKey(e => e.CityId);
                //wiecej stacji
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

            modelBuilder.Entity<LinkStations>(builder =>
            {
                builder.HasKey(e => new { e.StationId, e.LinkId });
                builder.Property(e => e.Number).IsRequired();
                builder.Property(e => e.DepartureTime);
                builder.Property(e => e.ArrivalTime);
                // type moze byc enum trzeba zrobic risercz
                builder.Property(e => e.Type);
                builder.HasOne(e => e.Station).WithMany(e => e.LinkStations).HasForeignKey(e => e.StationId);
                builder.HasOne(e => e.Link).WithMany(e => e.LinkStations).HasForeignKey(e => e.LinkId);
            });

            modelBuilder.Entity<RailLink>(builder =>
            {
                builder.HasKey(e => e.LinkId);
                builder.Property(e => e.Length);
                builder.Property(e => e.PlannedTime);
            });

            modelBuilder.Entity<Transit>(builder =>
            {
                builder.HasKey(e => e.TransitId);
                builder.HasOne(e => e.Link).WithMany(e => e.Transits).HasForeignKey(e => e.LinkId);
                builder.HasOne(e => e.Train).WithMany(e => e.Transits).HasForeignKey(e => e.TrainId);
            });

            modelBuilder.Entity<Train>(builder =>
            {
                builder.HasKey(e => e.TrainId);
            });

            modelBuilder.Entity<Ticket>(builder =>
            {
                builder.HasKey(e => e.TicketId);
                builder.HasOne(e => e.Transit).WithMany(e => e.Tickets).HasForeignKey(e => e.TransitId);
                builder.HasOne(e => e.Passenger).WithMany(e => e.Tickets).HasForeignKey(e => e.PassengerId);
            });

            modelBuilder.Entity<Passenger>(builder =>
            {
                builder.HasKey(e => e.PassengerId);
                builder.HasOne(e => e.Person).WithOne(e => e.Passenger);
            });

            modelBuilder.Entity<Person>(builder =>
            {
                builder.HasKey(e => e.PersonId);
                builder.HasOne(e => e.Employee).WithOne(e => e.Person);
                builder.HasOne(e => e.Passenger).WithOne(e => e.Person);
            });

            modelBuilder.Entity<Employee>(builder =>
            {
                builder.HasKey(e => e.EmployeeId);
                builder.HasOne(e => e.Person).WithOne(e => e.Employee);
                builder.HasOne(e => e.Driver).WithOne(e => e.Employee);
                builder.HasOne(e => e.Conductor).WithOne(e => e.Employee);
                builder.HasOne(e => e.Train).WithMany(e => e.Employees).HasForeignKey(e => e.TrainId);
            });

            modelBuilder.Entity<Driver>(builder =>
            {
                builder.HasKey(e => e.DriverId);
                builder.HasOne(e => e.Employee).WithOne(e => e.Driver);
            });

            modelBuilder.Entity<Conductor>(builder =>
            {
                builder.HasKey(e => e.ConductorId);
                builder.HasOne(e => e.Employee).WithOne(e => e.Conductor);
            });

            modelBuilder.Entity<Train>(builder =>
            {
                builder.HasKey(e => e.TrainId);
            });

            modelBuilder.Entity<Wagon>(builder =>
            {
                builder.HasKey(e => e.WagonId);
                builder.HasOne(e => e.Train).WithMany(e => e.Wagons).HasForeignKey(e => e.TrainId);
                builder.HasOne(e => e.OpenWagon).WithOne(e => e.Wagon);
                builder.HasOne(e => e.CompartmentWagon).WithOne(e => e.Wagon);
            });

            modelBuilder.Entity<OpenWagon>(builder =>
            {
                builder.HasKey(e => e.OpenWagonId);
                builder.HasOne(e => e.Wagon).WithOne(e => e.OpenWagon);
            });

            modelBuilder.Entity<CompartmentWagon>(builder =>
            {
                builder.HasKey(e => e.WagonId);
                builder.HasOne(e => e.Wagon).WithOne(e => e.CompartmentWagon);
            });

            modelBuilder.Entity<Seat>(builder =>
            {
                builder.HasKey(e => e.SeatId);
                builder.HasOne(e => e.Wagon).WithMany(e => e.Seats).HasForeignKey(e => e.WagonId);
            });
        }
    }
}