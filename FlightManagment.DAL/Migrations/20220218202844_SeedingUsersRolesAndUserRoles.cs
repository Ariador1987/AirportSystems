using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightManagment.DAL.Migrations
{
    public partial class SeedingUsersRolesAndUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0468917c-e1a0-459c-a187-f964f3a28911", "f486bfdb-6964-4b38-9d6b-5940f741cb7c", "Checker", "CHECKER" },
                    { "7e64a228-607e-4d71-aa2a-7c793358bdc0", "b270125b-b704-49ce-91e9-2bc23eb770e4", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "332286ba-b449-4bce-8628-f148088fa0e6", 0, "965525e0-fc59-4290-b60c-965865232e7f", "admin@as.com", false, "system", "admin", false, null, "ADMIN@AS.COM", "ADMIN@AS.COM", "AQAAAAEAACcQAAAAEFPuoan5PulRUUqrQNN+LNcMIqdRnUr8G5eIxOR1A6rdPr/27iojGF1RljLHwNbPLQ==", null, false, "68b7f39f-b8b6-4814-8b2f-2e06b85f1b4d", false, "admin@as.com" },
                    { "f5ee4379-a6b0-4350-9fed-6501306b7ff2", 0, "a68a9f66-f638-427f-82ed-ea3d7e386640", "checker@as.com", false, "system", "checker", false, null, "CHECKER@AS.COM", "CHECKER@AS.COM", "AQAAAAEAACcQAAAAEBJnFZ23xG0iGibr9csnCOdm4RleGG718sbWV6BhRJD6I0RqLtjmCk+tqi+J4KExGQ==", null, false, "579611f9-0f52-4895-83c5-cff2f2032f20", false, "checker@as.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7e64a228-607e-4d71-aa2a-7c793358bdc0", "332286ba-b449-4bce-8628-f148088fa0e6" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0468917c-e1a0-459c-a187-f964f3a28911", "f5ee4379-a6b0-4350-9fed-6501306b7ff2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7e64a228-607e-4d71-aa2a-7c793358bdc0", "332286ba-b449-4bce-8628-f148088fa0e6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0468917c-e1a0-459c-a187-f964f3a28911", "f5ee4379-a6b0-4350-9fed-6501306b7ff2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0468917c-e1a0-459c-a187-f964f3a28911");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e64a228-607e-4d71-aa2a-7c793358bdc0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "332286ba-b449-4bce-8628-f148088fa0e6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5ee4379-a6b0-4350-9fed-6501306b7ff2");
        }
    }
}
