using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class del : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fe896bc-bfae-4281-9c1c-47ddffde828e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a3daf20-fa59-40ab-a5c5-dbc0c46a3585");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b315df9a-5f4f-4b47-ad6b-a251385d159e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f390489c-7352-4437-81f3-b278d9da373c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08ef8412-dbbe-42c1-b800-02ef0d25000f", "2", "ApprovedStore", "ApprovedStore" },
                    { "5cd6b551-a996-42b7-97d0-aeb2bb216c70", "3", "PendingStore", "PendingStore" },
                    { "5f0a6a93-5bfc-411b-bdb2-0fbb44baaf5d", "4", "Customer", "Customer" },
                    { "a2553016-1831-4c03-84b2-6249836c2dbd", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08ef8412-dbbe-42c1-b800-02ef0d25000f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cd6b551-a996-42b7-97d0-aeb2bb216c70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f0a6a93-5bfc-411b-bdb2-0fbb44baaf5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2553016-1831-4c03-84b2-6249836c2dbd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2fe896bc-bfae-4281-9c1c-47ddffde828e", "4", "Customer", "Customer" },
                    { "5a3daf20-fa59-40ab-a5c5-dbc0c46a3585", "2", "ApprovedStore", "ApprovedStore" },
                    { "b315df9a-5f4f-4b47-ad6b-a251385d159e", "3", "PendingStore", "PendingStore" },
                    { "f390489c-7352-4437-81f3-b278d9da373c", "1", "Admin", "Admin" }
                });
        }
    }
}
