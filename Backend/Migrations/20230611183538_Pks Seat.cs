using Backend.Models.Enum;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class PksSeat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassengerId",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "OpenWagonId",
                table: "OpenWagons");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "ConductorId",
                table: "Conductors");

            migrationBuilder.DropColumn(
                name: "CompartmentWagonId",
                table: "CompartmentWagons");

            migrationBuilder.AddColumn<int>(
                name: "WagonNumber",
                table: "Seats",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 1,
                column: "WagonNumber",
                value: 1);

            migrationBuilder.InsertData(
                table: "Wagons",
                columns: new[] { "WagonId", "Class", "IsSeatRequired", "NumberOfSeats", "TrainId", "WagonNumber" },
                values: new object[] { 2, 2, null, 80, 1, 2 });

            migrationBuilder.InsertData(
                table: "OpenWagons",
                columns: new[] { "WagonId", "Type" },
                values: new object[] { 2, OpenWagonType.Normal });

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_Email",
                table: "Passengers",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Passengers_Email",
                table: "Passengers");

            migrationBuilder.DeleteData(
                table: "OpenWagons",
                keyColumn: "WagonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Wagons",
                keyColumn: "WagonId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "WagonNumber",
                table: "Seats");

            migrationBuilder.AddColumn<int>(
                name: "PassengerId",
                table: "Passengers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OpenWagonId",
                table: "OpenWagons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Drivers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConductorId",
                table: "Conductors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompartmentWagonId",
                table: "CompartmentWagons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "CompartmentWagons",
                keyColumn: "WagonId",
                keyValue: 1,
                column: "CompartmentWagonId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Passengers",
                keyColumn: "PersonId",
                keyValue: 1,
                column: "PassengerId",
                value: 0);
        }
    }
}
