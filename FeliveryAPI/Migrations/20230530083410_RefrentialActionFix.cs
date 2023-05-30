using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class RefrentialActionFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4254064c-b31c-47f6-96a5-a128b9113b47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96802d1d-2323-4361-add2-06bed46bca4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c90876d2-6446-4915-b390-573b388c6901");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1053c82-19f2-4e3a-a01a-6373a21e6a06");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "285f30ac-0055-4f88-b247-e48eea1e95e2", "1", "Admin", "Admin" },
                    { "3b66d28b-47d6-41e1-a639-05bcb836f85f", "3", "PendingStore", "PendingStore" },
                    { "4df8ff84-5657-429b-9fee-1519f208a2ca", "2", "ApprovedStore", "ApprovedStore" },
                    { "8cc85504-7982-4e50-a075-d7ec5a3c4bb0", "4", "Customer", "Customer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "285f30ac-0055-4f88-b247-e48eea1e95e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b66d28b-47d6-41e1-a639-05bcb836f85f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4df8ff84-5657-429b-9fee-1519f208a2ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cc85504-7982-4e50-a075-d7ec5a3c4bb0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4254064c-b31c-47f6-96a5-a128b9113b47", "2", "ApprovedStore", "ApprovedStore" },
                    { "96802d1d-2323-4361-add2-06bed46bca4f", "1", "Admin", "Admin" },
                    { "c90876d2-6446-4915-b390-573b388c6901", "3", "PendingStore", "PendingStore" },
                    { "f1053c82-19f2-4e3a-a01a-6373a21e6a06", "4", "Customer", "Customer" }
                });
        }
    }
}
