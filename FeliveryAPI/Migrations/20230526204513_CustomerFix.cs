using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class CustomerFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c23ffb7-d7d9-403a-ac18-621bd8d2e695");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6161090b-a853-4231-b506-fda12facc3b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb259a8d-691d-4592-afe8-921149c6c05c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebb84fb1-fc9c-4db9-9edc-1f74e8da09fd");

            migrationBuilder.AlterColumn<string>(
                name: "SecurityID",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SecurityID",
                table: "Customers",
                column: "SecurityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_SecurityID",
                table: "Customers",
                column: "SecurityID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_SecurityID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_SecurityID",
                table: "Customers");

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

            migrationBuilder.AlterColumn<string>(
                name: "SecurityID",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c23ffb7-d7d9-403a-ac18-621bd8d2e695", "1", "Admin", "Admin" },
                    { "6161090b-a853-4231-b506-fda12facc3b1", "3", "PendingStore", "PendingStore" },
                    { "bb259a8d-691d-4592-afe8-921149c6c05c", "2", "ApprovedStore", "ApprovedStore" },
                    { "ebb84fb1-fc9c-4db9-9edc-1f74e8da09fd", "4", "Customer", "Customer" }
                });
        }
    }
}
