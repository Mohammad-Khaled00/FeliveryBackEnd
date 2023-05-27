using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class NoAction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74716505-c2f2-4216-84aa-f6b849e3b30b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87d06f5c-2411-46c6-882b-0e2ee879d4d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af0416b5-a06a-4ac6-9275-ed68e565b72e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ceeaa3d0-9b41-4f56-a5b8-a95765266776");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "71f38bdf-43e0-4445-aa1a-1eb01d5be902", "2", "ApprovedStore", "ApprovedStore" },
                    { "e7279bc5-c802-43e0-9699-ab10d60204d6", "4", "Customer", "Customer" },
                    { "ed6f8ce1-3054-4406-9269-64931a75da1f", "3", "PendingStore", "PendingStore" },
                    { "ff717a8a-023a-49d2-b208-3f02df503737", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71f38bdf-43e0-4445-aa1a-1eb01d5be902");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7279bc5-c802-43e0-9699-ab10d60204d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed6f8ce1-3054-4406-9269-64931a75da1f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff717a8a-023a-49d2-b208-3f02df503737");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "74716505-c2f2-4216-84aa-f6b849e3b30b", "1", "Admin", "Admin" },
                    { "87d06f5c-2411-46c6-882b-0e2ee879d4d7", "3", "PendingStore", "PendingStore" },
                    { "af0416b5-a06a-4ac6-9275-ed68e565b72e", "2", "ApprovedStore", "ApprovedStore" },
                    { "ceeaa3d0-9b41-4f56-a5b8-a95765266776", "4", "Customer", "Customer" }
                });
        }
    }
}
