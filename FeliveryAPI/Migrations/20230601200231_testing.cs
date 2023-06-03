using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class testing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c7db34e-c85f-4ae5-be0b-8b3fb03ca6f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "609ffdfa-139c-40ca-932b-050645d7eb6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b35fc6da-abeb-4d03-90e5-fb54440f3f48");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2abc30a-6ef2-49a1-bb93-7626bb3e0b07");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a9d1977-e413-4bee-aa52-66a3a28822d5", "2", "ApprovedStore", "ApprovedStore" },
                    { "357d1ed8-9744-4050-b989-74afce671096", "4", "Customer", "Customer" },
                    { "724070a4-8777-4e98-bb9f-fe8007f31c29", "3", "PendingStore", "PendingStore" },
                    { "d05e8368-20d0-4b71-9f41-b8c7d17a6bc2", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a9d1977-e413-4bee-aa52-66a3a28822d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "357d1ed8-9744-4050-b989-74afce671096");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "724070a4-8777-4e98-bb9f-fe8007f31c29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d05e8368-20d0-4b71-9f41-b8c7d17a6bc2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c7db34e-c85f-4ae5-be0b-8b3fb03ca6f1", "3", "PendingStore", "PendingStore" },
                    { "609ffdfa-139c-40ca-932b-050645d7eb6d", "2", "ApprovedStore", "ApprovedStore" },
                    { "b35fc6da-abeb-4d03-90e5-fb54440f3f48", "1", "Admin", "Admin" },
                    { "c2abc30a-6ef2-49a1-bb93-7626bb3e0b07", "4", "Customer", "Customer" }
                });
        }
    }
}
