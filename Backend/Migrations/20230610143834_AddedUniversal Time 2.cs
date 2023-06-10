using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddedUniversalTime2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transits",
                keyColumn: "TransitId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transits",
                keyColumn: "TransitId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
