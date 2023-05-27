using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class addorderdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    MenuItemID = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderId, x.MenuItemID });
                    table.ForeignKey(
                        name: "FK_OrderDetails_MenuItems_MenuItemID",
                        column: x => x.MenuItemID,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "74716505-c2f2-4216-84aa-f6b849e3b30b", "1", "Admin", "Admin" },
                    { "87d06f5c-2411-46c6-882b-0e2ee879d4d7", "3", "PendingStore", "PendingStore" },
                    { "af0416b5-a06a-4ac6-9275-ed68e565b72e", "2", "ApprovedStore", "ApprovedStore" },
                    { "ceeaa3d0-9b41-4f56-a5b8-a95765266776", "4", "Customer", "Customer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_MenuItemID",
                table: "OrderDetails",
                column: "MenuItemID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74716505-c2f2-4216-84aa-f6b849e3b30b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87d06f5c-2411-46c6-882b-0e2ee879d4d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af0416b5-a06a-4ac6-9275-ed68e565b72e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ceeaa3d0-9b41-4f56-a5b8-a95765266776");

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
    }
}
