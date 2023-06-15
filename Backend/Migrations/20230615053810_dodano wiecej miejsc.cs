using Backend.Models.Enum;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class dodanowiecejmiejsc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "SeatId", "SeatNumber", "Type", "WagonId", "WagonNumber" },
                values: new object[,]
                {
                    { 2, 2, SeatType.Window, 1, 1 },
                    { 3, 3, SeatType.Window, 1, 1 },
                    { 4, 4, SeatType.Window, 1, 1 },
                    { 5, 5, SeatType.Window, 1, 1 },
                    { 6, 6, SeatType.Window, 1, 1 },
                    { 7, 7, SeatType.Window, 1, 1 },
                    { 8, 8, SeatType.Window, 1, 1 },
                    { 9, 9, SeatType.Window, 1, 1 },
                    { 10, 10, SeatType.Window, 1, 1 },
                    { 11, 11, SeatType.Window, 1, 1 },
                    { 12, 12, SeatType.Window, 1, 1 },
                    { 13, 13, SeatType.Window, 1, 1 },
                    { 14, 14, SeatType.Window, 1, 1 },
                    { 15, 15, SeatType.Window, 1, 1 },
                    { 16, 16, SeatType.Window, 1, 1 },
                    { 17, 17, SeatType.Window, 1, 1 },
                    { 18, 18, SeatType.Window, 1, 1 },
                    { 19, 19, SeatType.Window, 1, 1 },
                    { 20, 20, SeatType.Window, 1, 1 },
                    { 21, 21, SeatType.Window, 1, 1 },
                    { 22, 22, SeatType.Window, 1, 1 },
                    { 23, 23, SeatType.Window, 1, 1 },
                    { 24, 24, SeatType.Window, 1, 1 },
                    { 25, 25, SeatType.Window, 1, 1 },
                    { 26, 26, SeatType.Window, 1, 1 },
                    { 27, 27, SeatType.Window, 1, 1 },
                    { 28, 28, SeatType.Window, 1, 1 },
                    { 29, 29, SeatType.Window, 1, 1 },
                    { 30, 30, SeatType.Window, 1, 1 },
                    { 31, 31, SeatType.Window, 1, 1 },
                    { 32, 32, SeatType.Window, 1, 1 },
                    { 33, 33, SeatType.Window, 1, 1 },
                    { 34, 34, SeatType.Window, 1, 1 },
                    { 35, 35, SeatType.Window, 1, 1 },
                    { 36, 36, SeatType.Window, 1, 1 },
                    { 37, 37, SeatType.Window, 1, 1 },
                    { 38, 38, SeatType.Window, 1, 1 },
                    { 39, 39, SeatType.Window, 1, 1 },
                    { 40, 40, SeatType.Window, 1, 1 },
                    { 41, 1, SeatType.Window, 2, 2 },
                    { 42, 2, SeatType.Window, 2, 2 },
                    { 43, 3, SeatType.Window, 2, 2 },
                    { 44, 4, SeatType.Window, 2, 2 },
                    { 45, 5, SeatType.Window, 2, 2 },
                    { 46, 6, SeatType.Window, 2, 2 },
                    { 47, 7, SeatType.Window, 2, 2 },
                    { 48, 8, SeatType.Window, 2, 2 },
                    { 49, 9, SeatType.Window, 2, 2 },
                    { 50, 10, SeatType.Window, 2, 2 },
                    { 51, 11, SeatType.Window, 2, 2 },
                    { 52, 12, SeatType.Window, 2, 2 },
                    { 53, 13, SeatType.Window, 2, 2 },
                    { 54, 14, SeatType.Window, 2, 2 },
                    { 55, 15, SeatType.Window, 2, 2 },
                    { 56, 16, SeatType.Window, 2, 2 },
                    { 57, 17, SeatType.Window, 2, 2 },
                    { 58, 18, SeatType.Window, 2, 2 },
                    { 59, 19, SeatType.Window, 2, 2 },
                    { 60, 20, SeatType.Window, 2, 2 },
                    { 61, 21, SeatType.Window, 2, 2 },
                    { 62, 22, SeatType.Window, 2, 2 },
                    { 63, 23, SeatType.Window, 2, 2 },
                    { 64, 24, SeatType.Window, 2, 2 },
                    { 65, 25, SeatType.Window, 2, 2 },
                    { 66, 26, SeatType.Window, 2, 2 },
                    { 67, 27, SeatType.Window, 2, 2 },
                    { 68, 28, SeatType.Window, 2, 2 },
                    { 69, 29, SeatType.Window, 2, 2 },
                    { 70, 30, SeatType.Window, 2, 2 },
                    { 71, 31, SeatType.Window, 2, 2 },
                    { 72, 32, SeatType.Window, 2, 2 },
                    { 73, 33, SeatType.Window, 2, 2 },
                    { 74, 34, SeatType.Window, 2, 2 },
                    { 75, 35, SeatType.Window, 2, 2 },
                    { 76, 36, SeatType.Window, 2, 2 },
                    { 77, 37, SeatType.Window, 2, 2 },
                    { 78, 38, SeatType.Window, 2, 2 },
                    { 79, 39, SeatType.Window, 2, 2 },
                    { 80, 40, SeatType.Window, 2, 2 },
                    { 81, 41, SeatType.Window, 2, 2 },
                    { 82, 42, SeatType.Window, 2, 2 },
                    { 83, 43, SeatType.Window, 2, 2 },
                    { 84, 44, SeatType.Window, 2, 2 },
                    { 85, 45, SeatType.Window, 2, 2 },
                    { 86, 46, SeatType.Window, 2, 2 },
                    { 87, 47, SeatType.Window, 2, 2 },
                    { 88, 48, SeatType.Window, 2, 2 },
                    { 89, 49, SeatType.Window, 2, 2 },
                    { 90, 50, SeatType.Window, 2, 2 },
                    { 91, 51, SeatType.Window, 2, 2 },
                    { 92, 52, SeatType.Window, 2, 2 },
                    { 93, 53, SeatType.Window, 2, 2 },
                    { 94, 54, SeatType.Window, 2, 2 },
                    { 95, 55, SeatType.Window, 2, 2 },
                    { 96, 56, SeatType.Window, 2, 2 },
                    { 97, 57, SeatType.Window, 2, 2 },
                    { 98, 58, SeatType.Window, 2, 2 },
                    { 99, 59, SeatType.Window, 2, 2 },
                    { 100, 60, SeatType.Window, 2, 2 },
                    { 101, 61, SeatType.Window, 2, 2 },
                    { 102, 62, SeatType.Window, 2, 2 },
                    { 103, 63, SeatType.Window, 2, 2 },
                    { 104, 64, SeatType.Window, 2, 2 },
                    { 105, 65, SeatType.Window, 2, 2 },
                    { 106, 66, SeatType.Window, 2, 2 },
                    { 107, 67, SeatType.Window, 2, 2 },
                    { 108, 68, SeatType.Window, 2, 2 },
                    { 109, 69, SeatType.Window, 2, 2 },
                    { 110, 70, SeatType.Window, 2, 2 },
                    { 111, 71, SeatType.Window, 2, 2 },
                    { 112, 72, SeatType.Window, 2, 2 },
                    { 113, 73, SeatType.Window, 2, 2 },
                    { 114, 74, SeatType.Window, 2, 2 },
                    { 115, 75, SeatType.Window, 2, 2 },
                    { 116, 76, SeatType.Window, 2, 2 },
                    { 117, 77, SeatType.Window, 2, 2 },
                    { 118, 78, SeatType.Window, 2, 2 },
                    { 119, 79, SeatType.Window, 2, 2 },
                    { 120, 80, SeatType.Window, 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 120);
        }
    }
}
