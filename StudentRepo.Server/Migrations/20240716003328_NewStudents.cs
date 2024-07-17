using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentRepo.Server.Migrations
{
    /// <inheritdoc />
    public partial class NewStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "FirstName", "LastName", "Mobile", "NIC", "ProfileImage" },
                values: new object[,]
                {
                    { 4, "101 Maple St, Anytown, USA", new DateTime(1998, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.brown@example.com", "Bob", "Brown", "2233445566", "223344556V", "" },
                    { 5, "202 Cedar St, Anytown, USA", new DateTime(1997, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "charlie.davis@example.com", "Charlie", "Davis", "3344556677", "334455667V", "" },
                    { 6, "303 Birch St, Anytown, USA", new DateTime(2002, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "diana.evans@example.com", "Diana", "Evans", "4455667788", "445566778V", "" },
                    { 7, "404 Spruce St, Anytown, USA", new DateTime(1996, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "edward.frank@example.com", "Edward", "Frank", "5566778899", "556677889V", "" },
                    { 8, "505 Elm St, Anytown, USA", new DateTime(2003, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "fiona.green@example.com", "Fiona", "Green", "6677889900", "667788990V", "" },
                    { 9, "606 Ash St, Anytown, USA", new DateTime(2004, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "george.harris@example.com", "George", "Harris", "7788990011", "778899001V", "" },
                    { 10, "707 Willow St, Anytown, USA", new DateTime(2005, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "hannah.iverson@example.com", "Hannah", "Iverson", "8899001122", "889900112V", "" },
                    { 11, "808 Poplar St, Anytown, USA", new DateTime(1995, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ian.jackson@example.com", "Ian", "Jackson", "9900112233", "990011223V", "" },
                    { 12, "909 Walnut St, Anytown, USA", new DateTime(2006, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "julia.king@example.com", "Julia", "King", "0011223344", "001122334V", "" },
                    { 13, "1010 Cherry St, Anytown, USA", new DateTime(1994, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "kevin.lewis@example.com", "Kevin", "Lewis", "1122334455", "112233445V", "" },
                    { 14, "1111 Pineapple St, Anytown, USA", new DateTime(2007, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "laura.miller@example.com", "Laura", "Miller", "2233445566", "223344556V", "" },
                    { 15, "1212 Coconut St, Anytown, USA", new DateTime(2008, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.nelson@example.com", "Michael", "Nelson", "3344556677", "334455667V", "" },
                    { 16, "1313 Orange St, Anytown, USA", new DateTime(2009, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "nina.olsen@example.com", "Nina", "Olsen", "4455667788", "445566778V", "" },
                    { 17, "1414 Lemon St, Anytown, USA", new DateTime(2010, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "oscar.perez@example.com", "Oscar", "Perez", "5566778899", "556677889V", "" },
                    { 18, "1515 Grapefruit St, Anytown, USA", new DateTime(2011, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "paula.quinn@example.com", "Paula", "Quinn", "6677889900", "667788990V", "" },
                    { 19, "1616 Watermelon St, Anytown, USA", new DateTime(2012, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "quincy.roberts@example.com", "Quincy", "Roberts", "7788990011", "778899001V", "" },
                    { 20, "1717 Blueberry St, Anytown, USA", new DateTime(2013, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "rachel.smith@example.com", "Rachel", "Smith", "8899001122", "889900112V", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
