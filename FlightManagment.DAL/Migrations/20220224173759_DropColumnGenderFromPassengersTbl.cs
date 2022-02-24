using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightManagment.DAL.Migrations
{
    public partial class DropColumnGenderFromPassengersTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Passengers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0468917c-e1a0-459c-a187-f964f3a28911",
                column: "ConcurrencyStamp",
                value: "9778dd49-5fa8-4d39-965a-3e93e120d418");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e64a228-607e-4d71-aa2a-7c793358bdc0",
                column: "ConcurrencyStamp",
                value: "32555651-0585-4894-a2ae-fd5ff0575a2c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "332286ba-b449-4bce-8628-f148088fa0e6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f95c57c2-8431-458c-a4a5-60815b0e3034", "AQAAAAEAACcQAAAAEFyDEhi5m98g11+NAoiSZJE0d6XtYKOq5FL640SWcFmcL3WAa7CvAXRGpLTi26ypUA==", "d3c349fe-30e3-47a1-8eea-795e0b22df2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5ee4379-a6b0-4350-9fed-6501306b7ff2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "852fa70a-5832-4deb-a6f9-dc24c8be5af0", "AQAAAAEAACcQAAAAEE2GiC5xBUJ8BUMw6yOnmYqwq2iMX9koKKYOGVWZEyEYQl6an+cW1RJXOlAGBKd2Cw==", "beeb59dd-d459-4e91-83cc-f687afce4270" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
