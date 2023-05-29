using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class ImageUploading : Migration
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

            migrationBuilder.AlterColumn<string>(
                name: "MenuItemImg",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a6800e1-d24d-45c2-a558-883f85e81158", "1", "Admin", "Admin" },
                    { "81bd0896-6f8e-4485-96b1-80f5c16463d9", "3", "PendingStore", "PendingStore" },
                    { "993831a0-23fe-46dc-b739-3c760f2b843f", "4", "Customer", "Customer" },
                    { "f21f029a-9691-4417-b7cf-4dd9dac84c8d", "2", "ApprovedStore", "ApprovedStore" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a6800e1-d24d-45c2-a558-883f85e81158");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81bd0896-6f8e-4485-96b1-80f5c16463d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "993831a0-23fe-46dc-b739-3c760f2b843f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f21f029a-9691-4417-b7cf-4dd9dac84c8d");

            migrationBuilder.AlterColumn<string>(
                name: "MenuItemImg",
                table: "MenuItems",
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
                    { "56c1adcd-f7ae-45fc-8cd9-382dfd18f66b", "4", "Customer", "Customer" },
                    { "82742b0f-54e7-4412-bda5-9dbcc84df667", "1", "Admin", "Admin" },
                    { "c2e683a8-2afc-4bcc-a849-94eadf3fa84c", "3", "PendingStore", "PendingStore" },
                    { "e69df621-cc66-4917-9c5a-586cc43f39e8", "2", "ApprovedStore", "ApprovedStore" }
                });
        }
    }
}
