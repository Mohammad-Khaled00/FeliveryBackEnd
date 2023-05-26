using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class customer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Customers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "Address");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MobileNumber",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3de299ce-5cd9-4d75-9e83-337c8d636373", "1", "Admin", "Admin" },
                    { "5ace4706-4198-4efb-9c67-03be35bea878", "3", "PendingStore", "PendingStore" },
                    { "9a4d521a-efa9-4493-8089-955e4bbbb723", "2", "ApprovedStore", "ApprovedStore" },
                    { "a21657bf-74ff-4721-b21a-b014ae7fdfd7", "4", "Customer", "Customer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3de299ce-5cd9-4d75-9e83-337c8d636373");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ace4706-4198-4efb-9c67-03be35bea878");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a4d521a-efa9-4493-8089-955e4bbbb723");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a21657bf-74ff-4721-b21a-b014ae7fdfd7");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Customers",
                newName: "Name");

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
    }
}
