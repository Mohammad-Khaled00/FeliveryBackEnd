using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class CustomersecondFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44b60b1b-6475-443d-aa90-7da1c481777a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cfe21c9-f5b7-4152-ac79-9dbf0ddc3bea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4dd07f6-f7bf-4e13-873f-952042f1e3d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecc3eb28-ff49-4887-9793-a99edd599aa6");

            migrationBuilder.RenameColumn(
                name: "totalPrice",
                table: "Orders",
                newName: "TotalPrice");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0932e853-2f2e-4b0b-946f-8846740faae2", "2", "ApprovedStore", "ApprovedStore" },
                    { "0db3ace6-b5f7-49a5-b4c1-cfa95adc8490", "4", "Customer", "Customer" },
                    { "33eaaf24-1254-4dfd-8a41-c253927f9398", "3", "PendingStore", "PendingStore" },
                    { "6a0aac5d-1fc5-4e02-a0e9-bb4afdab53c4", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0932e853-2f2e-4b0b-946f-8846740faae2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0db3ace6-b5f7-49a5-b4c1-cfa95adc8490");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33eaaf24-1254-4dfd-8a41-c253927f9398");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a0aac5d-1fc5-4e02-a0e9-bb4afdab53c4");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Orders",
                newName: "totalPrice");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44b60b1b-6475-443d-aa90-7da1c481777a", "4", "Customer", "Customer" },
                    { "7cfe21c9-f5b7-4152-ac79-9dbf0ddc3bea", "3", "PendingStore", "PendingStore" },
                    { "a4dd07f6-f7bf-4e13-873f-952042f1e3d3", "2", "ApprovedStore", "ApprovedStore" },
                    { "ecc3eb28-ff49-4887-9793-a99edd599aa6", "1", "Admin", "Admin" }
                });
        }
    }
}
