using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Enum;
using Backend.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace API.Models
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
            NpgsqlConnection.GlobalTypeMapper.MapEnum<TransitState>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<StationType>();
            modelBuilder.HasPostgresEnum<OpenWagonType>();
            modelBuilder.HasPostgresEnum<SeatType>();
            modelBuilder.HasPostgresEnum<TransitState>();

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
                builder.HasOne(e => e.City).WithMany(e => e.TrainStations).HasForeignKey(e => e.CityId).IsRequired();
                //wiecej stacji
                builder.HasData(new TrainStation
                {
                    StationId = 1,
                    CityId = 1,
                    NumberOfPlatforms = 5,
                    NumberOfTracks = 10,
                    Name = "Warszawa Wschodnia",
                },
                new TrainStation
                {
                    StationId = 2,
                    CityId = 1,
                    NumberOfPlatforms = 5,
                    NumberOfTracks = 10,
                    Name = "Warszawa Centralna"
                },
                new TrainStation
                {
                    StationId = 3,
                    CityId = 1,
                    NumberOfPlatforms = 5,
                    NumberOfTracks = 10,
                    Name = "Warszawa Zachodnia"
                });

            });

            modelBuilder.Entity<LinkStations>(builder =>
            {
                builder.HasKey(e => new
                {
                    e.StationId,
                    e.LinkId
                });
                builder.HasOne(e => e.Station).WithMany(e => e.LinkStations).HasForeignKey(e => e.StationId).IsRequired();
                builder.HasOne(e => e.Link).WithMany(e => e.LinkStations).HasForeignKey(e => e.LinkId).IsRequired();
                builder.HasData(
                    new LinkStations
                    {
                        StationId = 1,
                        LinkId = 1,
                        Number = 1,
                        DepartureTime = new TimeOnly(12, 0, 0),
                        Type = StationType.StartStation
                    },
                    new LinkStations
                    {
                        StationId = 2,
                        LinkId = 1,
                        Number = 2,
                        DepartureTime = new TimeOnly(12, 5, 0),
                        ArrivalTime = new TimeOnly(12, 7, 0),
                    },
                    new LinkStations
                    {
                        StationId = 3,
                        LinkId = 1,
                        Number = 3,
                        ArrivalTime = new TimeOnly(12, 10, 0),
                        Type = StationType.EndStation
                    }
                );
            });

            modelBuilder.Entity<RailLink>(builder =>
            {
                builder.HasKey(e => e.LinkId);
                builder.Property(e => e.Length);
                builder.Property(e => e.PlannedTime);
                builder.HasData(new RailLink
                {
                    LinkId = 1,
                    Length = 10,
                    PlannedTime = 10
                });
            });

            modelBuilder.Entity<Transit>(builder =>
            {
                builder.HasKey(e => e.TransitId);
                builder.HasOne(e => e.Link).WithMany(e => e.Transits).HasForeignKey(e => e.LinkId).IsRequired();
                builder.HasOne(e => e.Train).WithMany(e => e.Transits).HasForeignKey(e => e.TrainId).IsRequired();
                builder.HasData(new Transit
                {
                    TransitId = 1,
                    LinkId = 1,
                    TrainId = 1,
                    Date = new DateTime(2023, 1, 1).ToUniversalTime(),
                    delay = 0,
                    state = TransitState.Waiting
                });
            });

            modelBuilder.Entity<Train>(builder =>
            {
                builder.HasKey(e => e.TrainId);
                builder.HasData(new Train
                {
                    TrainId = 1,
                    Name = "Orzeszkowa",
                    Type = "IC"
                });
            });

            modelBuilder.Entity<Ticket>(builder =>
            {
                builder.HasKey(e => e.TicketId);
                builder.HasOne(e => e.Transit).WithMany(e => e.Tickets).HasForeignKey(e => e.TransitId).IsRequired();
                builder.HasOne(e => e.Passenger).WithMany(e => e.Tickets).HasForeignKey(e => e.PassengerId).IsRequired();
                builder.HasData(new Ticket
                {
                    TicketId = 1,
                    TransitId = 1,
                    PassengerId = 1,
                    DepartureTime = new DateTime(2023, 1, 1, 12, 0, 0).ToUniversalTime(),
                    Price = 10,
                    Wagon = 1,
                    Seat = 1,
                    SeatType = SeatType.Window
                });
            });

            modelBuilder.Entity<Person>(builder =>
            {
                builder.UseTptMappingStrategy();
                builder.HasKey(e => e.PersonId);
                builder.HasOne(e => e.Passenger).WithOne(e => e.Person).HasForeignKey<Passenger>(e => e.PersonId);
                builder.HasOne(e => e.Employee).WithOne(e => e.Person).HasForeignKey<Employee>(e => e.PersonId);
            });

            modelBuilder.Entity<Employee>(builder =>
            {
                builder.UseTptMappingStrategy();
                builder.HasOne(e => e.Train).WithMany(e => e.Employees).HasForeignKey(e => e.TrainId);
            });

            modelBuilder.Entity<Passenger>(builder =>
            {
                builder.HasIndex(e => e.Email).IsUnique();
                builder.HasData(new Passenger
                {
                    PersonId = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Email = "jan.kwalski@mail.com",
                    PhoneNumber = "123456789",
                    Pasword = "1234"
                });
            });

            modelBuilder.Entity<Wagon>(builder =>
            {
                builder.UseTptMappingStrategy();
                builder.HasKey(e => e.WagonId);
                builder.HasOne(e => e.Train).WithMany(e => e.Wagons).HasForeignKey(e => e.TrainId).IsRequired();
                builder.HasOne(e => e.CompartmentWagon).WithOne(e => e.Wagon).HasForeignKey<CompartmentWagon>(e => e.WagonId);
                builder.HasOne(e => e.OpenWagon).WithOne(e => e.Wagon).HasForeignKey<OpenWagon>(e => e.WagonId);
            });

            modelBuilder.Entity<CompartmentWagon>(builder =>
            {
                builder.HasData(new CompartmentWagon
                {
                    WagonId = 1,
                    WagonNumber = 1,
                    TrainId = 1,
                    NumberOfCompartments = 10,
                    Class = 1,
                    IsSeatRequired = true
                });
            });

            modelBuilder.Entity<OpenWagon>(builder =>
            {
                builder.HasData(new OpenWagon
                {
                    WagonId = 2,
                    WagonNumber = 2,
                    TrainId = 1,
                    Type = OpenWagonType.Normal,
                    Class = 2,
                });
            });

            modelBuilder.Entity<Seat>(builder =>
            {
                builder.HasKey(e => e.SeatId);
                builder.HasOne(e => e.Wagon).WithMany(e => e.Seats).HasForeignKey(e => e.WagonId).IsRequired();
                Seat[] seats = new Seat[40];
                seats = Enumerable.Range(1, 40).Select(i => new Seat
                {
                    SeatId = i,
                    WagonId = 1,
                    SeatNumber = i,
                    WagonNumber = 1,
                    Type = SeatType.Window
                }).ToArray();
                builder.HasData(seats);
                Seat[] seatsOpen = Enumerable.Range(1, 80).Select(i => new Seat
                {
                    SeatId = i + 40,
                    WagonId = 2,
                    SeatNumber = i,
                    WagonNumber = 2,
                    Type = SeatType.Window
                }).ToArray();
                builder.HasData(seatsOpen);
            });
        }
    }
}