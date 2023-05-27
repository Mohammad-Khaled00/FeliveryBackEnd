using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class MenuAndOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "19675012-c121-435e-85e9-ca1d72a4a9f1", "3", "PendingStore", "PendingStore" },
                    { "4df78d42-2929-4427-aa4a-8dc2fe7dbd3d", "4", "Customer", "Customer" },
                    { "78b41d1f-42b1-409e-b746-2d8eeaa0a44c", "2", "ApprovedStore", "ApprovedStore" },
                    { "89d447fe-240f-46ea-ba6f-c4dc7e57f36a", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19675012-c121-435e-85e9-ca1d72a4a9f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4df78d42-2929-4427-aa4a-8dc2fe7dbd3d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78b41d1f-42b1-409e-b746-2d8eeaa0a44c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89d447fe-240f-46ea-ba6f-c4dc7e57f36a");

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
    }
}
