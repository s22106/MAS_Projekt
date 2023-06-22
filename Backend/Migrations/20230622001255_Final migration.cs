using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Finalmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfSeats",
                table: "Wagons");

            migrationBuilder.RenameColumn(
                name: "bonus",
                table: "Conductors",
                newName: "role");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role",
                table: "Conductors",
                newName: "bonus");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSeats",
                table: "Wagons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Wagons",
                keyColumn: "WagonId",
                keyValue: 1,
                column: "NumberOfSeats",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Wagons",
                keyColumn: "WagonId",
                keyValue: 2,
                column: "NumberOfSeats",
                value: 80);
        }
    }
}
