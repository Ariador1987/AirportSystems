using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightManagment.DAL.Migrations
{
    public partial class AddGenderToPassengerTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Passengers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0468917c-e1a0-459c-a187-f964f3a28911",
                column: "ConcurrencyStamp",
                value: "52ece827-229c-4c2a-944c-3f1871a14410");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e64a228-607e-4d71-aa2a-7c793358bdc0",
                column: "ConcurrencyStamp",
                value: "0653a0ad-0de7-4cf2-89d8-f88432ca633c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "332286ba-b449-4bce-8628-f148088fa0e6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "535da0ed-d491-4b27-a32d-222accc8f3ee", "AQAAAAEAACcQAAAAEM4eaXPP7ifGjTFzJIdVeC+CmnIKZxX7EpptVKgQ+cArTPesOwbvx8CHTRxvZ1Knvw==", "132bb1e1-faa7-418e-9e2b-3cbfecb7477e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5ee4379-a6b0-4350-9fed-6501306b7ff2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1cd7962d-3be8-4016-b492-7f45486ac02c", "AQAAAAEAACcQAAAAEDT4mwsA566ap0NSLAsISpQLZ/aHqo9s9aCgQ3vPub59fRZ3Fwj6fZQbKLNLOrkYPA==", "bbe94366-ded3-4a8b-b724-a204ceb18795" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Passengers");

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
        }
    }
}
