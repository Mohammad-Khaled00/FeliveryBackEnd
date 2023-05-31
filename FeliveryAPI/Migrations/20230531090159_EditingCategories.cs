using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class EditingCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01c98915-674e-4894-8770-97cd3884c85b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1348a3ad-3f1b-469a-bc73-3d0a52e35fdd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "895b1b87-fac5-4f69-b328-58c088db2af4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffe01d07-2dd3-48d8-a5df-651d2006b5eb");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOffer",
                table: "MenuItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "328c3ad7-e96b-4d5f-94fc-b87d422e9b7a", "2", "ApprovedStore", "ApprovedStore" },
                    { "3366e491-5774-4c1c-b124-e0d7914fdcb9", "3", "PendingStore", "PendingStore" },
                    { "6a0434e0-1da5-4dd7-a31d-353f65c42ee7", "4", "Customer", "Customer" },
                    { "a333ba52-1355-49bb-96ac-f40cabad19bd", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "328c3ad7-e96b-4d5f-94fc-b87d422e9b7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3366e491-5774-4c1c-b124-e0d7914fdcb9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a0434e0-1da5-4dd7-a31d-353f65c42ee7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a333ba52-1355-49bb-96ac-f40cabad19bd");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "IsOffer",
                table: "MenuItems");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01c98915-674e-4894-8770-97cd3884c85b", "2", "ApprovedStore", "ApprovedStore" },
                    { "1348a3ad-3f1b-469a-bc73-3d0a52e35fdd", "3", "PendingStore", "PendingStore" },
                    { "895b1b87-fac5-4f69-b328-58c088db2af4", "1", "Admin", "Admin" },
                    { "ffe01d07-2dd3-48d8-a5df-651d2006b5eb", "4", "Customer", "Customer" }
                });
        }
    }
}
