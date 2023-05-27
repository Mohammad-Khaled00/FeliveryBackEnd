using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class ODetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bd3c3e1-23ab-4cce-b7f0-467174024f46");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "578815d9-ea84-4b96-bcab-4db9d97c1aef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a12bb616-348d-47e3-baa4-6995e4114c7c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbfd8f2b-3986-4065-8efb-744da10ff57a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e10af8e-198c-45a5-8ddb-6cca87ff74a2", "1", "Admin", "Admin" },
                    { "8f2ffa50-2e81-41de-bf01-8eb6f33b3fe1", "2", "ApprovedStore", "ApprovedStore" },
                    { "93ecd10b-3898-444f-a671-18d857235c72", "3", "PendingStore", "PendingStore" },
                    { "f9b951c8-1a03-45b2-ae9b-c8d4c458138f", "4", "Customer", "Customer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e10af8e-198c-45a5-8ddb-6cca87ff74a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f2ffa50-2e81-41de-bf01-8eb6f33b3fe1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93ecd10b-3898-444f-a671-18d857235c72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9b951c8-1a03-45b2-ae9b-c8d4c458138f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bd3c3e1-23ab-4cce-b7f0-467174024f46", "3", "PendingStore", "PendingStore" },
                    { "578815d9-ea84-4b96-bcab-4db9d97c1aef", "4", "Customer", "Customer" },
                    { "a12bb616-348d-47e3-baa4-6995e4114c7c", "1", "Admin", "Admin" },
                    { "fbfd8f2b-3986-4065-8efb-744da10ff57a", "2", "ApprovedStore", "ApprovedStore" }
                });
        }
    }
}
