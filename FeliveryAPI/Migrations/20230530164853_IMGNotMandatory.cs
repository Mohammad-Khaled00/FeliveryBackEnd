using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class IMGNotMandatory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "StoreImg",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "060ec780-1e9a-4cbf-aed2-c6dd7dafdeb3", "3", "PendingStore", "PendingStore" },
                    { "1a1f944c-a37b-4098-b414-c6a104dc768d", "4", "Customer", "Customer" },
                    { "91f328b3-36d7-4d13-94f0-3e8c57f5f192", "1", "Admin", "Admin" },
                    { "a66d1440-f29f-45b4-b2ae-2f61decbe965", "2", "ApprovedStore", "ApprovedStore" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "060ec780-1e9a-4cbf-aed2-c6dd7dafdeb3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a1f944c-a37b-4098-b414-c6a104dc768d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91f328b3-36d7-4d13-94f0-3e8c57f5f192");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a66d1440-f29f-45b4-b2ae-2f61decbe965");

            migrationBuilder.AlterColumn<string>(
                name: "StoreImg",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
