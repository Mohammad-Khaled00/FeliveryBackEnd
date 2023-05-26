using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class CustomerController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "SecurityID",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "SecurityID",
                table: "Customers");

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
    }
}
