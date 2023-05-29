using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class RestCateg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56c1adcd-f7ae-45fc-8cd9-382dfd18f66b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82742b0f-54e7-4412-bda5-9dbcc84df667");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2e683a8-2afc-4bcc-a849-94eadf3fa84c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e69df621-cc66-4917-9c5a-586cc43f39e8");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantID",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54d2e354-c2e0-4903-a7e2-08bc2d365420", "4", "Customer", "Customer" },
                    { "5dfab681-b8c5-4bd3-9351-390ea5faaf1a", "3", "PendingStore", "PendingStore" },
                    { "c5ec2b0a-3cd6-40f2-8846-7a173fb4c49f", "2", "ApprovedStore", "ApprovedStore" },
                    { "e8851e28-323c-4db5-a0ce-bb96e15af24a", "1", "Admin", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_RestaurantID",
                table: "Categories",
                column: "RestaurantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Restaurants_RestaurantID",
                table: "Categories",
                column: "RestaurantID",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Restaurants_RestaurantID",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_RestaurantID",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54d2e354-c2e0-4903-a7e2-08bc2d365420");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5dfab681-b8c5-4bd3-9351-390ea5faaf1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5ec2b0a-3cd6-40f2-8846-7a173fb4c49f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8851e28-323c-4db5-a0ce-bb96e15af24a");

            migrationBuilder.DropColumn(
                name: "RestaurantID",
                table: "Categories");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "56c1adcd-f7ae-45fc-8cd9-382dfd18f66b", "4", "Customer", "Customer" },
                    { "82742b0f-54e7-4412-bda5-9dbcc84df667", "1", "Admin", "Admin" },
                    { "c2e683a8-2afc-4bcc-a849-94eadf3fa84c", "3", "PendingStore", "PendingStore" },
                    { "e69df621-cc66-4917-9c5a-586cc43f39e8", "2", "ApprovedStore", "ApprovedStore" }
                });
        }
    }
}
