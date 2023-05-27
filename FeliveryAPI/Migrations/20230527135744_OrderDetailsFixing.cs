using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class OrderDetailsFixing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "030c048a-f56d-4b3f-8aaa-d6f9f65cad31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f126e8-08c4-4de5-9d52-a198a3a04b16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c8c5bfc-9a31-4141-b4b2-021ae8648946");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee1b9797-e000-4e4b-9d4c-b3b17fcd5b0d");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "030c048a-f56d-4b3f-8aaa-d6f9f65cad31", "2", "ApprovedStore", "ApprovedStore" },
                    { "03f126e8-08c4-4de5-9d52-a198a3a04b16", "3", "PendingStore", "PendingStore" },
                    { "4c8c5bfc-9a31-4141-b4b2-021ae8648946", "4", "Customer", "Customer" },
                    { "ee1b9797-e000-4e4b-9d4c-b3b17fcd5b0d", "1", "Admin", "Admin" }
                });
        }
    }
}
