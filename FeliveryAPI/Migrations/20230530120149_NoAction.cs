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
                keyValue: "1a466df2-3b99-40cb-8a6e-cf39953b1a0c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ae288d9-8808-4a4b-8703-101c340e4be7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a30f7692-51b6-4364-b116-49fef8b70e7b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2f976df-acde-40e5-a7a7-cd71c01df2a7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c1ae686-559f-4461-bd39-295906433e7f", "4", "Customer", "Customer" },
                    { "3318a0bf-10ff-4b23-a805-f705353d9576", "3", "PendingStore", "PendingStore" },
                    { "73c30766-6da7-4fb2-a182-52554424984a", "2", "ApprovedStore", "ApprovedStore" },
                    { "adac113c-9701-42f7-8598-6e9eee864b14", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c1ae686-559f-4461-bd39-295906433e7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3318a0bf-10ff-4b23-a805-f705353d9576");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73c30766-6da7-4fb2-a182-52554424984a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adac113c-9701-42f7-8598-6e9eee864b14");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a466df2-3b99-40cb-8a6e-cf39953b1a0c", "4", "Customer", "Customer" },
                    { "8ae288d9-8808-4a4b-8703-101c340e4be7", "3", "PendingStore", "PendingStore" },
                    { "a30f7692-51b6-4364-b116-49fef8b70e7b", "1", "Admin", "Admin" },
                    { "c2f976df-acde-40e5-a7a7-cd71c01df2a7", "2", "ApprovedStore", "ApprovedStore" }
                });
        }
    }
}
