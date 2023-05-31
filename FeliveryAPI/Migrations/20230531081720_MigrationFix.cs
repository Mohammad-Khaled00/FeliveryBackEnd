using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class MigrationFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "037d032e-cc0c-4db5-8895-12bdb08372c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "358cdbb5-b59d-4cab-8d00-4a8a2a205f43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60c5ff11-d3ac-476b-a96c-65b3e4ff4469");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cd256c6-05f8-4e84-b6db-b19ed089802b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01c98915-674e-4894-8770-97cd3884c85b", "2", "ApprovedStore", "ApprovedStore" },
                    { "1348a3ad-3f1b-469a-bc73-3d0a52e35fdd", "3", "PendingStore", "PendingStore" },
                    { "895b1b87-fac5-4f69-b328-58c088db2af4", "1", "Admin", "Admin" },
                    { "ffe01d07-2dd3-48d8-a5df-651d2006b5eb", "4", "Customer", "Customer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01c98915-674e-4894-8770-97cd3884c85b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1348a3ad-3f1b-469a-bc73-3d0a52e35fdd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "895b1b87-fac5-4f69-b328-58c088db2af4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffe01d07-2dd3-48d8-a5df-651d2006b5eb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "037d032e-cc0c-4db5-8895-12bdb08372c5", "1", "Admin", "Admin" },
                    { "358cdbb5-b59d-4cab-8d00-4a8a2a205f43", "2", "ApprovedStore", "ApprovedStore" },
                    { "60c5ff11-d3ac-476b-a96c-65b3e4ff4469", "4", "Customer", "Customer" },
                    { "7cd256c6-05f8-4e84-b6db-b19ed089802b", "3", "PendingStore", "PendingStore" }
                });
        }
    }
}
