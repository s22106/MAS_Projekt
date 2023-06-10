﻿// <auto-generated />
using System;
using API.Models;
using API.Models.Enum;
using Backend.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(MASDbContext))]
    [Migration("20230610144755_Added TimeOnly 2")]
    partial class AddedTimeOnly2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "open_wagon_type", new[] { "silent", "normal", "restaurant" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "seat_type", new[] { "window", "aisle", "middle" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "station_type", new[] { "end_station", "start_station" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "transit_state", new[] { "delayed", "finished", "waiting" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CityId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            Name = "Warszawa"
                        });
                });

            modelBuilder.Entity("API.Models.LinkStations", b =>
                {
                    b.Property<int>("StationId")
                        .HasColumnType("integer");

                    b.Property<int>("LinkId")
                        .HasColumnType("integer");

                    b.Property<TimeOnly?>("ArrivalTime")
                        .HasColumnType("time without time zone");

                    b.Property<TimeOnly?>("DepartureTime")
                        .HasColumnType("time without time zone");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<StationType?>("Type")
                        .HasColumnType("station_type");

                    b.HasKey("StationId", "LinkId");

                    b.HasIndex("LinkId");

                    b.ToTable("LinkStations");

                    b.HasData(
                        new
                        {
                            StationId = 1,
                            LinkId = 1,
                            DepartureTime = new TimeOnly(12, 0, 0),
                            Number = 1,
                            Type = StationType.StartStation
                        },
                        new
                        {
                            StationId = 2,
                            LinkId = 1,
                            ArrivalTime = new TimeOnly(12, 7, 0),
                            DepartureTime = new TimeOnly(12, 5, 0),
                            Number = 2
                        },
                        new
                        {
                            StationId = 3,
                            LinkId = 1,
                            ArrivalTime = new TimeOnly(12, 10, 0),
                            Number = 3,
                            Type = StationType.EndStation
                        });
                });

            modelBuilder.Entity("API.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PersonId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("API.Models.RailLink", b =>
                {
                    b.Property<int>("LinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LinkId"));

                    b.Property<int>("Length")
                        .HasColumnType("integer");

                    b.Property<int>("PlannedTime")
                        .HasColumnType("integer");

                    b.HasKey("LinkId");

                    b.ToTable("RailLinks");

                    b.HasData(
                        new
                        {
                            LinkId = 1,
                            Length = 10,
                            PlannedTime = 10
                        });
                });

            modelBuilder.Entity("API.Models.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SeatId"));

                    b.Property<int>("SeatNumber")
                        .HasColumnType("integer");

                    b.Property<SeatType>("Type")
                        .HasColumnType("seat_type");

                    b.Property<int>("WagonId")
                        .HasColumnType("integer");

                    b.HasKey("SeatId");

                    b.HasIndex("WagonId");

                    b.ToTable("Seats");

                    b.HasData(
                        new
                        {
                            SeatId = 1,
                            SeatNumber = 1,
                            Type = SeatType.Window,
                            WagonId = 1
                        });
                });

            modelBuilder.Entity("API.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TicketId"));

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PassengerId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Seat")
                        .HasColumnType("integer");

                    b.Property<SeatType>("SeatType")
                        .HasColumnType("seat_type");

                    b.Property<int>("TransitId")
                        .HasColumnType("integer");

                    b.Property<int>("Wagon")
                        .HasColumnType("integer");

                    b.HasKey("TicketId");

                    b.HasIndex("PassengerId");

                    b.HasIndex("TransitId");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            TicketId = 1,
                            DepartureTime = new DateTime(2023, 1, 1, 11, 0, 0, 0, DateTimeKind.Utc),
                            PassengerId = 1,
                            Price = 10m,
                            Seat = 1,
                            SeatType = SeatType.Window,
                            TransitId = 1,
                            Wagon = 1
                        });
                });

            modelBuilder.Entity("API.Models.Train", b =>
                {
                    b.Property<int>("TrainId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TrainId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("TrainId");

                    b.ToTable("Trains");

                    b.HasData(
                        new
                        {
                            TrainId = 1,
                            Name = "Orzeszkowa",
                            Type = "IC"
                        });
                });

            modelBuilder.Entity("API.Models.TrainStation", b =>
                {
                    b.Property<int>("StationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StationId"));

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumberOfPlatforms")
                        .HasColumnType("integer");

                    b.Property<int>("NumberOfTracks")
                        .HasColumnType("integer");

                    b.HasKey("StationId");

                    b.HasIndex("CityId");

                    b.ToTable("TrainStations");

                    b.HasData(
                        new
                        {
                            StationId = 1,
                            CityId = 1,
                            Name = "Warszawa Wschodnia",
                            NumberOfPlatforms = 5,
                            NumberOfTracks = 10
                        },
                        new
                        {
                            StationId = 2,
                            CityId = 1,
                            Name = "Warszawa Centralna",
                            NumberOfPlatforms = 5,
                            NumberOfTracks = 10
                        },
                        new
                        {
                            StationId = 3,
                            CityId = 1,
                            Name = "Warszawa Zachodnia",
                            NumberOfPlatforms = 5,
                            NumberOfTracks = 10
                        });
                });

            modelBuilder.Entity("API.Models.Transit", b =>
                {
                    b.Property<int>("TransitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TransitId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("LinkId")
                        .HasColumnType("integer");

                    b.Property<int>("TrainId")
                        .HasColumnType("integer");

                    b.Property<int>("delay")
                        .HasColumnType("integer");

                    b.Property<TransitState>("state")
                        .HasColumnType("transit_state");

                    b.HasKey("TransitId");

                    b.HasIndex("LinkId");

                    b.HasIndex("TrainId");

                    b.ToTable("Transits");

                    b.HasData(
                        new
                        {
                            TransitId = 1,
                            Date = new DateTime(2022, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc),
                            LinkId = 1,
                            TrainId = 1,
                            delay = 0,
                            state = TransitState.Waiting
                        });
                });

            modelBuilder.Entity("API.Models.Wagon", b =>
                {
                    b.Property<int>("WagonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("WagonId"));

                    b.Property<int>("Class")
                        .HasColumnType("integer");

                    b.Property<bool?>("IsSeatRequired")
                        .HasColumnType("boolean");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("integer");

                    b.Property<int>("TrainId")
                        .HasColumnType("integer");

                    b.Property<int>("WagonNumber")
                        .HasColumnType("integer");

                    b.HasKey("WagonId");

                    b.HasIndex("TrainId");

                    b.ToTable("Wagons");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("API.Models.Employee", b =>
                {
                    b.HasBaseType("API.Models.Person");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EmploymentDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("TrainId")
                        .HasColumnType("integer");

                    b.HasIndex("TrainId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("API.Models.Passenger", b =>
                {
                    b.HasBaseType("API.Models.Person");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("PassengerId")
                        .HasColumnType("integer");

                    b.Property<string>("Pasword")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("Passengers");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            FirstName = "Jan",
                            LastName = "Kowalski",
                            Email = "jan.kwalski@mail.com",
                            PassengerId = 0,
                            Pasword = "1234",
                            PhoneNumber = "123456789"
                        });
                });

            modelBuilder.Entity("API.Models.CompartmentWagon", b =>
                {
                    b.HasBaseType("API.Models.Wagon");

                    b.Property<int>("CompartmentWagonId")
                        .HasColumnType("integer");

                    b.Property<int>("NumberOfCompartments")
                        .HasColumnType("integer");

                    b.ToTable("CompartmentWagons");

                    b.HasData(
                        new
                        {
                            WagonId = 1,
                            Class = 1,
                            IsSeatRequired = true,
                            NumberOfSeats = 40,
                            TrainId = 1,
                            WagonNumber = 1,
                            CompartmentWagonId = 0,
                            NumberOfCompartments = 10
                        });
                });

            modelBuilder.Entity("API.Models.OpenWagon", b =>
                {
                    b.HasBaseType("API.Models.Wagon");

                    b.Property<int>("OpenWagonId")
                        .HasColumnType("integer");

                    b.Property<OpenWagonType>("Type")
                        .HasColumnType("open_wagon_type");

                    b.ToTable("OpenWagons");
                });

            modelBuilder.Entity("API.Models.Conductor", b =>
                {
                    b.HasBaseType("API.Models.Employee");

                    b.Property<int>("ConductorId")
                        .HasColumnType("integer");

                    b.Property<string>("bonus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("Conductors");
                });

            modelBuilder.Entity("API.Models.Driver", b =>
                {
                    b.HasBaseType("API.Models.Employee");

                    b.Property<int>("DriverId")
                        .HasColumnType("integer");

                    b.Property<int>("bonus")
                        .HasColumnType("integer");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("API.Models.LinkStations", b =>
                {
                    b.HasOne("API.Models.RailLink", "Link")
                        .WithMany("LinkStations")
                        .HasForeignKey("LinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.TrainStation", "Station")
                        .WithMany("LinkStations")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Link");

                    b.Navigation("Station");
                });

            modelBuilder.Entity("API.Models.Seat", b =>
                {
                    b.HasOne("API.Models.Wagon", "Wagon")
                        .WithMany("Seats")
                        .HasForeignKey("WagonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wagon");
                });

            modelBuilder.Entity("API.Models.Ticket", b =>
                {
                    b.HasOne("API.Models.Passenger", "Passenger")
                        .WithMany("Tickets")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Transit", "Transit")
                        .WithMany("Tickets")
                        .HasForeignKey("TransitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");

                    b.Navigation("Transit");
                });

            modelBuilder.Entity("API.Models.TrainStation", b =>
                {
                    b.HasOne("API.Models.City", "City")
                        .WithMany("TrainStations")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("API.Models.Transit", b =>
                {
                    b.HasOne("API.Models.RailLink", "Link")
                        .WithMany("Transits")
                        .HasForeignKey("LinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Train", "Train")
                        .WithMany("Transits")
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Link");

                    b.Navigation("Train");
                });

            modelBuilder.Entity("API.Models.Wagon", b =>
                {
                    b.HasOne("API.Models.Train", "Train")
                        .WithMany("Wagons")
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Train");
                });

            modelBuilder.Entity("API.Models.Employee", b =>
                {
                    b.HasOne("API.Models.Person", "Person")
                        .WithOne("Employee")
                        .HasForeignKey("API.Models.Employee", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Train", "Train")
                        .WithMany("Employees")
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Train");
                });

            modelBuilder.Entity("API.Models.Passenger", b =>
                {
                    b.HasOne("API.Models.Person", "Person")
                        .WithOne("Passenger")
                        .HasForeignKey("API.Models.Passenger", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("API.Models.CompartmentWagon", b =>
                {
                    b.HasOne("API.Models.Wagon", "Wagon")
                        .WithOne("CompartmentWagon")
                        .HasForeignKey("API.Models.CompartmentWagon", "WagonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wagon");
                });

            modelBuilder.Entity("API.Models.OpenWagon", b =>
                {
                    b.HasOne("API.Models.Wagon", "Wagon")
                        .WithOne("OpenWagon")
                        .HasForeignKey("API.Models.OpenWagon", "WagonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wagon");
                });

            modelBuilder.Entity("API.Models.Conductor", b =>
                {
                    b.HasOne("API.Models.Employee", null)
                        .WithOne()
                        .HasForeignKey("API.Models.Conductor", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Models.Driver", b =>
                {
                    b.HasOne("API.Models.Employee", null)
                        .WithOne()
                        .HasForeignKey("API.Models.Driver", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Models.City", b =>
                {
                    b.Navigation("TrainStations");
                });

            modelBuilder.Entity("API.Models.Person", b =>
                {
                    b.Navigation("Employee");

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("API.Models.RailLink", b =>
                {
                    b.Navigation("LinkStations");

                    b.Navigation("Transits");
                });

            modelBuilder.Entity("API.Models.Train", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Transits");

                    b.Navigation("Wagons");
                });

            modelBuilder.Entity("API.Models.TrainStation", b =>
                {
                    b.Navigation("LinkStations");
                });

            modelBuilder.Entity("API.Models.Transit", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("API.Models.Wagon", b =>
                {
                    b.Navigation("CompartmentWagon")
                        .IsRequired();

                    b.Navigation("OpenWagon")
                        .IsRequired();

                    b.Navigation("Seats");
                });

            modelBuilder.Entity("API.Models.Passenger", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
