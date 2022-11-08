using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sarenza.DAL.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "GETDATE()"),
                    TemperatureC = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HotTemperature = table.Column<double>(type: "REAL", nullable: false),
                    ColdTemperature = table.Column<double>(type: "REAL", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "History",
                columns: new[] { "Id", "Date", "TemperatureC" },
                values: new object[] { 1, new DateTime(2022, 11, 8, 15, 27, 50, 715, DateTimeKind.Utc).AddTicks(9423), 22.0 });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "ColdTemperature", "CreationDateTime", "HotTemperature" },
                values: new object[] { 1, 22.0, new DateTime(2022, 11, 8, 15, 27, 50, 715, DateTimeKind.Utc).AddTicks(9247), 40.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
