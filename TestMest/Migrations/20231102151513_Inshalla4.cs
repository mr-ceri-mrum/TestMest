using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestMest.Migrations
{
    /// <inheritdoc />
    public partial class Inshalla4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6cc8b37f-5899-4fda-96e9-10d94cef851a");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "799cdc6e-6095-40fd-accd-ebf731b56fd0", 0, "f3153109-71e9-4109-964b-9f2038c703a0", "Ilyas@mail.com", false, true, null, null, null, "AQAAAAIAAYagAAAAEIFHqhDboJkEoR8KfKdUBgo+BTdeFp5Ff/+3W/cBo4kYImOfRc7H136eXRWS+ANOMQ==", null, false, "MKMGDOFK6H75S3G2X4AZS73R4Z7B7OQ3", false, "root@mail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "799cdc6e-6095-40fd-accd-ebf731b56fd0");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6cc8b37f-5899-4fda-96e9-10d94cef851a", 0, "f3153109-71e9-4109-964b-9f2038c703a0", "Ilyas@mail.com", false, true, null, null, null, "AQAAAAIAAYagAAAAEIFHqhDboJkEoR8KfKdUBgo+BTdeFp5Ff/+3W/cBo4kYImOfRc7H136eXRWS+ANOMQ==", null, false, "MKMGDOFK6H75S3G2X4AZS73R4Z7B7OQ3", false, "root@mail.com" });
        }
    }
}
