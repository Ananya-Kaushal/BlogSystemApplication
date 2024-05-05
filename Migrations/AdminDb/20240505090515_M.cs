using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogSystem.Migrations.AdminDb
{
    /// <inheritdoc />
    public partial class M : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "37cc67e1-41ca-461c-bf34-2b5e62dbae32", "37cc67e1-41ca-461c-bf34-2b5e62dbae32", "Admin", "Admin" },
                    { "3cfd9eee-08cb-4da3-9e6f-c3166b50d3b0", "3cfd9eee-08cb-4da3-9e6f-c3166b50d3b0", "SuperAdmin", "SuperAdmin" },
                    { "a0cab2c3-6558-4a1c-be81-dfb39180da3d", "a0cab2c3-6558-4a1c-be81-dfb39180da3d", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "472ba632-6133-44a1-b158-6c10bd7d850d", 0, "0510e3f3-cb44-4bde-ada8-4ffdb611a64f", "superadmin@bloggie.com", false, false, null, "SUPERADMIN@BLOGGIE.COM", "SUPERADMIN@BLOGGIE.COM", "AQAAAAIAAYagAAAAEAowHqDf6pjTqiW1Q5FYblAY7EEqTXzzbXo2IsU3ofuSmRInIoCJm29V5HQ+d85Pdw==", null, false, "c1585ff1-d08d-45a8-aa8f-0349d04f4232", false, "superadmin@bloggie.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "37cc67e1-41ca-461c-bf34-2b5e62dbae32", "472ba632-6133-44a1-b158-6c10bd7d850d" },
                    { "3cfd9eee-08cb-4da3-9e6f-c3166b50d3b0", "472ba632-6133-44a1-b158-6c10bd7d850d" },
                    { "a0cab2c3-6558-4a1c-be81-dfb39180da3d", "472ba632-6133-44a1-b158-6c10bd7d850d" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "37cc67e1-41ca-461c-bf34-2b5e62dbae32", "472ba632-6133-44a1-b158-6c10bd7d850d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3cfd9eee-08cb-4da3-9e6f-c3166b50d3b0", "472ba632-6133-44a1-b158-6c10bd7d850d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a0cab2c3-6558-4a1c-be81-dfb39180da3d", "472ba632-6133-44a1-b158-6c10bd7d850d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37cc67e1-41ca-461c-bf34-2b5e62dbae32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cfd9eee-08cb-4da3-9e6f-c3166b50d3b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0cab2c3-6558-4a1c-be81-dfb39180da3d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "472ba632-6133-44a1-b158-6c10bd7d850d");
        }
    }
}
