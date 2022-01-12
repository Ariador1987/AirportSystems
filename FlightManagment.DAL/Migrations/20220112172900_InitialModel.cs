using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightManagment.DAL.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ConstructionDate = table.Column<DateTime>(type: "date", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Airports_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Croatia" },
                    { 2, "Italy" },
                    { 3, "Germany" },
                    { 4, "Slovenia" },
                    { 5, "Austria" },
                    { 6, "Poland" }
                });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "ConstructionDate", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2014, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Split" },
                    { 2, new DateTime(2012, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Palermo" },
                    { 3, new DateTime(2017, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Frankfurt" },
                    { 4, new DateTime(2018, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Ljubljana" },
                    { 5, new DateTime(2013, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Graz" },
                    { 6, new DateTime(2017, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Warsaw" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airports_CountryId",
                table: "Airports",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
