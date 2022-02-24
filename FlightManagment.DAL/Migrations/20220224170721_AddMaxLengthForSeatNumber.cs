using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightManagment.DAL.Migrations
{
    public partial class AddMaxLengthForSeatNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SeatNumber",
                table: "Passengers",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0468917c-e1a0-459c-a187-f964f3a28911",
                column: "ConcurrencyStamp",
                value: "d3efadfd-05f8-4fcf-8b16-5ac90d9c8193");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e64a228-607e-4d71-aa2a-7c793358bdc0",
                column: "ConcurrencyStamp",
                value: "3005358b-0544-42d3-9c35-b888158ebee3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "332286ba-b449-4bce-8628-f148088fa0e6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa10515f-f358-47f4-bd23-492ac95d93f1", "AQAAAAEAACcQAAAAEJklDvZ8oZpWmWJ85ux6jHIYdbCuQShqlXcwHJ/4FKYYVfLz1VirxcbV5POhESmp8g==", "de82f84d-b18b-45f5-9a99-cb4e6feb61c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5ee4379-a6b0-4350-9fed-6501306b7ff2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9164678-ab99-42f9-a0aa-1ee3e7ead955", "AQAAAAEAACcQAAAAELA1vA914S/lTGwK92IG9G2koCDmiJ3TUyelmsPO8ZMn3zL2tULDDQGo3LV4SDhRmw==", "542ad960-1778-4b34-8123-b02dc490ff89" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SeatNumber",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

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
    }
}
