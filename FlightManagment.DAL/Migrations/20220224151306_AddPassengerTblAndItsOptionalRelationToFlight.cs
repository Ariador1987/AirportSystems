using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightManagment.DAL.Migrations
{
    public partial class AddPassengerTblAndItsOptionalRelationToFlight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: true),
                    SeatNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isCheckedIn = table.Column<bool>(type: "bit", nullable: false),
                    CHeckInTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passengers_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0468917c-e1a0-459c-a187-f964f3a28911",
                column: "ConcurrencyStamp",
                value: "352cdc42-2f74-485a-bbe1-870bef5bf2da");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e64a228-607e-4d71-aa2a-7c793358bdc0",
                column: "ConcurrencyStamp",
                value: "660edb51-ae71-486b-b10a-f09af9fe2391");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "332286ba-b449-4bce-8628-f148088fa0e6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "657b99d9-2658-4087-9073-28294bd5fee0", "AQAAAAEAACcQAAAAECRp1DYtqfvGPpExKPHxW2Tu8pMLDvYtuARTcIr8bnH+cELeQIYhLgkNewq50rPsWg==", "9fd2d7f2-5a6d-4164-bb50-c1dd344744e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5ee4379-a6b0-4350-9fed-6501306b7ff2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69a9a5e9-656d-497f-bdb7-6358d09054b6", "AQAAAAEAACcQAAAAEHOrJeZbTgBR13J2m6A8PvM5KA+LCfS+lBwDUZYOKsQ3cfy8IDhXn09V9UUnukaEQA==", "ecf4dfab-67e2-46b2-9dd8-bce96438716a" });

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_FlightId",
                table: "Passengers",
                column: "FlightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0468917c-e1a0-459c-a187-f964f3a28911",
                column: "ConcurrencyStamp",
                value: "f486bfdb-6964-4b38-9d6b-5940f741cb7c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e64a228-607e-4d71-aa2a-7c793358bdc0",
                column: "ConcurrencyStamp",
                value: "b270125b-b704-49ce-91e9-2bc23eb770e4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "332286ba-b449-4bce-8628-f148088fa0e6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "965525e0-fc59-4290-b60c-965865232e7f", "AQAAAAEAACcQAAAAEFPuoan5PulRUUqrQNN+LNcMIqdRnUr8G5eIxOR1A6rdPr/27iojGF1RljLHwNbPLQ==", "68b7f39f-b8b6-4814-8b2f-2e06b85f1b4d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5ee4379-a6b0-4350-9fed-6501306b7ff2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a68a9f66-f638-427f-82ed-ea3d7e386640", "AQAAAAEAACcQAAAAEBJnFZ23xG0iGibr9csnCOdm4RleGG718sbWV6BhRJD6I0RqLtjmCk+tqi+J4KExGQ==", "579611f9-0f52-4895-83c5-cff2f2032f20" });
        }
    }
}
