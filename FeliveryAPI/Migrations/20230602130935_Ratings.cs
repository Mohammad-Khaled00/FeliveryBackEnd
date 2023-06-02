using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class Ratings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "NumOfRaters",
                table: "Restaurants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalRatings",
                table: "Restaurants",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4fe01f93-f4c1-4987-b102-e8e5d90aef85", "2", "ApprovedStore", "ApprovedStore" },
                    { "9d2611ae-b5a4-4954-a6a3-ac22bfe68e03", "3", "PendingStore", "PendingStore" },
                    { "e2fb189c-8324-40d5-8312-ed6658edd764", "1", "Admin", "Admin" },
                    { "e4d6b16f-b99d-435f-9bd4-39dd7bfafd25", "4", "Customer", "Customer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fe01f93-f4c1-4987-b102-e8e5d90aef85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d2611ae-b5a4-4954-a6a3-ac22bfe68e03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2fb189c-8324-40d5-8312-ed6658edd764");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4d6b16f-b99d-435f-9bd4-39dd7bfafd25");

            migrationBuilder.DropColumn(
                name: "NumOfRaters",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "TotalRatings",
                table: "Restaurants");

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
    }
}
