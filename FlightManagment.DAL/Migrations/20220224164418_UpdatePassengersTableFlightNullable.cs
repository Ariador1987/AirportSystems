using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightManagment.DAL.Migrations
{
    public partial class UpdatePassengersTableFlightNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Flights_FlightId",
                table: "Passengers");

            migrationBuilder.AlterColumn<int>(
                name: "FlightId",
                table: "Passengers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0468917c-e1a0-459c-a187-f964f3a28911",
                column: "ConcurrencyStamp",
                value: "211c7bf6-606d-43fc-944d-8d3d29197cff");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e64a228-607e-4d71-aa2a-7c793358bdc0",
                column: "ConcurrencyStamp",
                value: "ab27aba5-b8b9-46ed-b137-d06ef05b98d1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "332286ba-b449-4bce-8628-f148088fa0e6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99c3dfde-2a06-48de-90af-f5cdc7f20391", "AQAAAAEAACcQAAAAEBaZKJEPrrO/MvI2YnwHQnLctamai+Pw3k+morJ5Efcu6LOaJKgRXKvmdj40+E3XAg==", "00be5a93-da52-42f5-8d96-fde81be0cf3a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5ee4379-a6b0-4350-9fed-6501306b7ff2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e86f4f63-f69b-44ec-8276-56ccd42d9bc3", "AQAAAAEAACcQAAAAEKhiTSkPt+E+gAH40LtQ2bsXQRZRH6Tyov0bbEJxv3Hp95jhlVZDcrqsWO19dwtHuA==", "3bfed459-e1fb-42b5-9e40-2d5f8e7d1bc2" });

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Flights_FlightId",
                table: "Passengers",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Flights_FlightId",
                table: "Passengers");

            migrationBuilder.AlterColumn<int>(
                name: "FlightId",
                table: "Passengers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Flights_FlightId",
                table: "Passengers",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
