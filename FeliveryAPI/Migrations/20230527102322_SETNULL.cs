using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class SETNULL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01c01996-ddfd-4dd1-88d4-f356d6a53fd5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "880cf8ae-8dc9-45f0-9b1c-6e7b9635d92f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aade5839-b2cf-45fa-b912-3d0272afc44e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e07646a4-edf1-4bb1-9c3c-924be607aada");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "031cb417-f2d8-46dc-919d-127ee015a5df", "4", "Customer", "Customer" },
                    { "b2dbcb2f-4661-474d-9252-4776df57c0b9", "3", "PendingStore", "PendingStore" },
                    { "bbeb54d2-a63d-4d46-9334-a334ea159d5c", "2", "ApprovedStore", "ApprovedStore" },
                    { "f2d43ef9-4a0f-4919-895f-15b80b028099", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "031cb417-f2d8-46dc-919d-127ee015a5df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2dbcb2f-4661-474d-9252-4776df57c0b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbeb54d2-a63d-4d46-9334-a334ea159d5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2d43ef9-4a0f-4919-895f-15b80b028099");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01c01996-ddfd-4dd1-88d4-f356d6a53fd5", "2", "ApprovedStore", "ApprovedStore" },
                    { "880cf8ae-8dc9-45f0-9b1c-6e7b9635d92f", "3", "PendingStore", "PendingStore" },
                    { "aade5839-b2cf-45fa-b912-3d0272afc44e", "4", "Customer", "Customer" },
                    { "e07646a4-edf1-4bb1-9c3c-924be607aada", "1", "Admin", "Admin" }
                });
        }
    }
}
