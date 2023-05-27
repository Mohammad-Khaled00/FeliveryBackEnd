using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class delorderdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

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
                    { "1d2fd615-a25c-4335-a4a3-d3a7468e9fe5", "2", "ApprovedStore", "ApprovedStore" },
                    { "228cbc86-8ff0-40d0-8abe-f8d7954e2d1e", "4", "Customer", "Customer" },
                    { "e2a709d4-4076-4685-970f-f1e9e7cb0c3f", "3", "PendingStore", "PendingStore" },
                    { "e853db0d-783a-4216-a347-d55c1fc80368", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d2fd615-a25c-4335-a4a3-d3a7468e9fe5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "228cbc86-8ff0-40d0-8abe-f8d7954e2d1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2a709d4-4076-4685-970f-f1e9e7cb0c3f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e853db0d-783a-4216-a347-d55c1fc80368");

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    MeniItemID = table.Column<int>(type: "int", nullable: false),
                    menuItemId = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderId, x.MeniItemID });
                    table.ForeignKey(
                        name: "FK_OrderDetails_MenuItems_menuItemId",
                        column: x => x.menuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_menuItemId",
                table: "OrderDetails",
                column: "menuItemId");
        }
    }
}
