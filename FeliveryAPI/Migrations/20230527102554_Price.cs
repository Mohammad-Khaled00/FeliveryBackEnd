using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class Price : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "price",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "303e5c9d-fc85-42f6-bdb3-a95bfaf2de5c", "1", "Admin", "Admin" },
                    { "36283e0e-6d4e-48d4-80f2-33e2c6458668", "3", "PendingStore", "PendingStore" },
                    { "d57e2618-3e76-4a23-afbf-1a034f770a92", "2", "ApprovedStore", "ApprovedStore" },
                    { "eb8413da-aa7b-47be-91bb-1ec22954cd79", "4", "Customer", "Customer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "303e5c9d-fc85-42f6-bdb3-a95bfaf2de5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36283e0e-6d4e-48d4-80f2-33e2c6458668");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d57e2618-3e76-4a23-afbf-1a034f770a92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb8413da-aa7b-47be-91bb-1ec22954cd79");

            migrationBuilder.DropColumn(
                name: "price",
                table: "OrderDetails");

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
    }
}
