using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class orderStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Orders",
                type: "bit",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d5024cc-b0a4-4a11-9720-9bca43df5234", "4", "Customer", "Customer" },
                    { "64dad01f-a18e-4392-8710-d307ddfa0ae5", "3", "PendingStore", "PendingStore" },
                    { "9e1fc1fe-16ec-40e9-b567-8f6f6954b690", "2", "ApprovedStore", "ApprovedStore" },
                    { "a5264233-7123-4c5b-8d51-301a668d40b5", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d5024cc-b0a4-4a11-9720-9bca43df5234");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64dad01f-a18e-4392-8710-d307ddfa0ae5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e1fc1fe-16ec-40e9-b567-8f6f6954b690");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5264233-7123-4c5b-8d51-301a668d40b5");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

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
    }
}
