using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentRepo.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NIC = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "FirstName", "LastName", "Mobile", "NIC", "ProfileImage" },
                values: new object[,]
                {
                    { 1, "123 Main St, Anytown, USA", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", "Doe", "1234567890", "123456789V", "" },
                    { 2, "456 Oak St, Anytown, USA", new DateTime(2001, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.doe@example.com", "Jane", "Doe", "0987654321", "987654321V", "" },
                    { 3, "789 Pine St, Anytown, USA", new DateTime(1999, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice.smith@example.com", "Alice", "Smith", "1122334455", "112233445V", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
