using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class addingroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0767cca9-0510-4666-bee2-5e8b9bc393ce", "2", "ApprovedStore", "ApprovedStore" },
                    { "5c371e23-8145-4073-8ad2-734f289e2857", "4", "Customer", "Customer" },
                    { "c714717f-9b39-4978-92b4-f660032e13c7", "1", "Admin", "Admin" },
                    { "d7d56f5f-8ff9-4fdf-8cde-a93ba7f7889f", "3", "PendingStore", "PendingStore" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0767cca9-0510-4666-bee2-5e8b9bc393ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c371e23-8145-4073-8ad2-734f289e2857");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c714717f-9b39-4978-92b4-f660032e13c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7d56f5f-8ff9-4fdf-8cde-a93ba7f7889f");
        }
    }
}
