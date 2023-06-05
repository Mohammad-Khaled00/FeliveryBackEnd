using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class RatingUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e878532-f0fd-4462-8429-5413a3165e9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ce525cd-c814-434c-aafd-0393cf58773e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d9d9582-ecd4-4d8f-b7c9-ceea4fa19095");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "931aa61f-9f8e-48c1-9ecc-204e1a6d7e46");

            migrationBuilder.AlterColumn<int>(
                name: "TotalRatings",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumOfRaters",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e2f2cc6-5efb-4d63-970d-020bf7a4ccd1", "1", "Admin", "Admin" },
                    { "3cb2c144-cbdc-4a00-bae9-d5858ffe6f27", "4", "Customer", "Customer" },
                    { "865b0e04-74e9-40aa-851c-0469f10de410", "2", "ApprovedStore", "ApprovedStore" },
                    { "9c0d2f6f-d121-4882-aa92-1ab9df628852", "3", "PendingStore", "PendingStore" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e2f2cc6-5efb-4d63-970d-020bf7a4ccd1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cb2c144-cbdc-4a00-bae9-d5858ffe6f27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "865b0e04-74e9-40aa-851c-0469f10de410");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c0d2f6f-d121-4882-aa92-1ab9df628852");

            migrationBuilder.AlterColumn<int>(
                name: "TotalRatings",
                table: "Restaurants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NumOfRaters",
                table: "Restaurants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e878532-f0fd-4462-8429-5413a3165e9c", "4", "Customer", "Customer" },
                    { "5ce525cd-c814-434c-aafd-0393cf58773e", "1", "Admin", "Admin" },
                    { "7d9d9582-ecd4-4d8f-b7c9-ceea4fa19095", "3", "PendingStore", "PendingStore" },
                    { "931aa61f-9f8e-48c1-9ecc-204e1a6d7e46", "2", "ApprovedStore", "ApprovedStore" }
                });
        }
    }
}
