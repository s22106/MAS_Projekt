using System;
using API.Models.Enum;
using Backend.Models.Enum;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:open_wagon_type", "silent,normal,restaurant")
                .Annotation("Npgsql:Enum:seat_type", "window,aisle,middle")
                .Annotation("Npgsql:Enum:station_type", "end_station,start_station")
                .Annotation("Npgsql:Enum:transit_state", "delayed,finished,waiting");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "RailLinks",
                columns: table => new
                {
                    LinkId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Length = table.Column<int>(type: "integer", nullable: false),
                    PlannedTime = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RailLinks", x => x.LinkId);
                });

            migrationBuilder.CreateTable(
                name: "Trains",
                columns: table => new
                {
                    TrainId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Type = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trains", x => x.TrainId);
                });

            migrationBuilder.CreateTable(
                name: "TrainStations",
                columns: table => new
                {
                    StationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    NumberOfPlatforms = table.Column<int>(type: "integer", nullable: false),
                    NumberOfTracks = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainStations", x => x.StationId);
                    table.ForeignKey(
                        name: "FK_TrainStations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "integer", nullable: false),
                    PassengerId = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Pasword = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Passengers_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    TrainId = table.Column<int>(type: "integer", nullable: false),
                    EmploymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Employees_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Trains",
                        principalColumn: "TrainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transits",
                columns: table => new
                {
                    TransitId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LinkId = table.Column<int>(type: "integer", nullable: false),
                    TrainId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    delay = table.Column<int>(type: "integer", nullable: false),
                    state = table.Column<TransitState>(type: "transit_state", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transits", x => x.TransitId);
                    table.ForeignKey(
                        name: "FK_Transits_RailLinks_LinkId",
                        column: x => x.LinkId,
                        principalTable: "RailLinks",
                        principalColumn: "LinkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transits_Trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Trains",
                        principalColumn: "TrainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wagons",
                columns: table => new
                {
                    WagonId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrainId = table.Column<int>(type: "integer", nullable: false),
                    Class = table.Column<int>(type: "integer", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "integer", nullable: false),
                    IsSeatRequired = table.Column<bool>(type: "boolean", nullable: true),
                    WagonNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wagons", x => x.WagonId);
                    table.ForeignKey(
                        name: "FK_Wagons_Trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Trains",
                        principalColumn: "TrainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkStations",
                columns: table => new
                {
                    LinkId = table.Column<int>(type: "integer", nullable: false),
                    StationId = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    DepartureTime = table.Column<TimeSpan>(type: "interval", nullable: true),
                    ArrivalTime = table.Column<TimeSpan>(type: "interval", nullable: true),
                    Type = table.Column<StationType>(type: "station_type", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkStations", x => new { x.StationId, x.LinkId });
                    table.ForeignKey(
                        name: "FK_LinkStations_RailLinks_LinkId",
                        column: x => x.LinkId,
                        principalTable: "RailLinks",
                        principalColumn: "LinkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkStations_TrainStations_StationId",
                        column: x => x.StationId,
                        principalTable: "TrainStations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conductors",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "integer", nullable: false),
                    ConductorId = table.Column<int>(type: "integer", nullable: false),
                    bonus = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conductors", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Conductors_Employees_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Employees",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "integer", nullable: false),
                    DriverId = table.Column<int>(type: "integer", nullable: false),
                    bonus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Drivers_Employees_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Employees",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransitId = table.Column<int>(type: "integer", nullable: false),
                    PassengerId = table.Column<int>(type: "integer", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Wagon = table.Column<int>(type: "integer", nullable: false),
                    Seat = table.Column<int>(type: "integer", nullable: false),
                    SeatType = table.Column<SeatType>(type: "seat_type", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Transits_TransitId",
                        column: x => x.TransitId,
                        principalTable: "Transits",
                        principalColumn: "TransitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompartmentWagons",
                columns: table => new
                {
                    WagonId = table.Column<int>(type: "integer", nullable: false),
                    CompartmentWagonId = table.Column<int>(type: "integer", nullable: false),
                    NumberOfCompartments = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompartmentWagons", x => x.WagonId);
                    table.ForeignKey(
                        name: "FK_CompartmentWagons_Wagons_WagonId",
                        column: x => x.WagonId,
                        principalTable: "Wagons",
                        principalColumn: "WagonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenWagons",
                columns: table => new
                {
                    WagonId = table.Column<int>(type: "integer", nullable: false),
                    OpenWagonId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<OpenWagonType>(type: "open_wagon_type", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenWagons", x => x.WagonId);
                    table.ForeignKey(
                        name: "FK_OpenWagons_Wagons_WagonId",
                        column: x => x.WagonId,
                        principalTable: "Wagons",
                        principalColumn: "WagonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WagonId = table.Column<int>(type: "integer", nullable: false),
                    SeatNumber = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<SeatType>(type: "seat_type", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seats_Wagons_WagonId",
                        column: x => x.WagonId,
                        principalTable: "Wagons",
                        principalColumn: "WagonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "Name" },
                values: new object[] { 1, "Warszawa" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "FirstName", "LastName" },
                values: new object[] { 1, "Jan", "Kowalski" });

            migrationBuilder.InsertData(
                table: "RailLinks",
                columns: new[] { "LinkId", "Length", "PlannedTime" },
                values: new object[] { 1, 10, 10 });

            migrationBuilder.InsertData(
                table: "Trains",
                columns: new[] { "TrainId", "Name", "Type" },
                values: new object[] { 1, "Orzeszkowa", "IC" });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "PersonId", "Email", "PassengerId", "Pasword", "PhoneNumber" },
                values: new object[] { 1, "jan.kwalski@mail.com", 0, "1234", "123456789" });

            migrationBuilder.InsertData(
                table: "TrainStations",
                columns: new[] { "StationId", "CityId", "Name", "NumberOfPlatforms", "NumberOfTracks" },
                values: new object[,]
                {
                    { 1, 1, "Warszawa Wschodnia", 5, 10 },
                    { 2, 1, "Warszawa Centralna", 5, 10 },
                    { 3, 1, "Warszawa Zachodnia", 5, 10 }
                });

            migrationBuilder.InsertData(
                table: "Transits",
                columns: new[] { "TransitId", "Date", "LinkId", "TrainId", "delay", "state" },
                values: new object[] { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 0, TransitState.Waiting });

            migrationBuilder.InsertData(
                table: "Wagons",
                columns: new[] { "WagonId", "Class", "IsSeatRequired", "NumberOfSeats", "TrainId", "WagonNumber" },
                values: new object[] { 1, 1, true, 40, 1, 1 });

            migrationBuilder.InsertData(
                table: "CompartmentWagons",
                columns: new[] { "WagonId", "CompartmentWagonId", "NumberOfCompartments" },
                values: new object[] { 1, 0, 10 });

            migrationBuilder.InsertData(
                table: "LinkStations",
                columns: new[] { "LinkId", "StationId", "ArrivalTime", "DepartureTime", "Number", "Type" },
                values: new object[,]
                {
                    { 1, 1, null, new TimeSpan(0, 12, 0, 0, 0), 1, StationType.StartStation },
                    { 1, 2, new TimeSpan(0, 12, 7, 0, 0), new TimeSpan(0, 12, 5, 0, 0), 2, null },
                    { 1, 3, new TimeSpan(0, 12, 10, 0, 0), null, 3, StationType.EndStation }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "SeatId", "SeatNumber", "Type", "WagonId" },
                values: new object[] { 1, 1, SeatType.Window, 1 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "DepartureTime", "PassengerId", "Price", "Seat", "SeatType", "TransitId", "Wagon" },
                values: new object[] { 1, new DateTime(2023, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 10m, 1, SeatType.Window, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TrainId",
                table: "Employees",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkStations_LinkId",
                table: "LinkStations",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_WagonId",
                table: "Seats",
                column: "WagonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PassengerId",
                table: "Tickets",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TransitId",
                table: "Tickets",
                column: "TransitId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainStations_CityId",
                table: "TrainStations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Transits_LinkId",
                table: "Transits",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Transits_TrainId",
                table: "Transits",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_Wagons_TrainId",
                table: "Wagons",
                column: "TrainId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompartmentWagons");

            migrationBuilder.DropTable(
                name: "Conductors");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "LinkStations");

            migrationBuilder.DropTable(
                name: "OpenWagons");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "TrainStations");

            migrationBuilder.DropTable(
                name: "Wagons");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Transits");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "RailLinks");

            migrationBuilder.DropTable(
                name: "Trains");
        }
    }
}
