using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddedTimeOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "DepartureTime",
                table: "LinkStations",
                type: "time without time zone",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "interval",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "ArrivalTime",
                table: "LinkStations",
                type: "time without time zone",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "interval",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "LinkStations",
                keyColumns: new[] { "LinkId", "StationId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { null, new TimeOnly(12, 0, 0) });

            migrationBuilder.UpdateData(
                table: "LinkStations",
                keyColumns: new[] { "LinkId", "StationId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new TimeOnly(12, 7, 0), new TimeOnly(12, 5, 0) });

            migrationBuilder.UpdateData(
                table: "LinkStations",
                keyColumns: new[] { "LinkId", "StationId" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new TimeOnly(12, 10, 0), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "DepartureTime",
                table: "LinkStations",
                type: "interval",
                nullable: true,
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ArrivalTime",
                table: "LinkStations",
                type: "interval",
                nullable: true,
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "LinkStations",
                keyColumns: new[] { "LinkId", "StationId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { null, new TimeSpan(0, 12, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "LinkStations",
                keyColumns: new[] { "LinkId", "StationId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new TimeSpan(0, 12, 7, 0, 0), new TimeSpan(0, 12, 5, 0, 0) });

            migrationBuilder.UpdateData(
                table: "LinkStations",
                keyColumns: new[] { "LinkId", "StationId" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new TimeSpan(0, 12, 10, 0, 0), null });
        }
    }
}
