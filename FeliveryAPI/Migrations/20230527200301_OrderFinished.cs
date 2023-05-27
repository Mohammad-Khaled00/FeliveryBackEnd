using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class OrderFinished : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MenuItems");

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
    }
}
