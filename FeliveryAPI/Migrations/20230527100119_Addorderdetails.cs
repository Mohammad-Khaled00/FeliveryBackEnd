using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class Addorderdetails : Migration
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
                    orderDetailsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    MenuItemID = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.orderDetailsID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_MenuItems_MenuItemID",
                        column: x => x.MenuItemID,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { "3ebbfb39-caae-47e1-b0be-0d531475c9d3", "2", "ApprovedStore", "ApprovedStore" },
                    { "74152c16-66be-468a-97a1-83e35ca6f874", "4", "Customer", "Customer" },
                    { "a4e1eec4-d803-43b0-9167-997607f55ec7", "1", "Admin", "Admin" },
                    { "ec2fd5d9-53cd-408b-8709-64cfd28ffa45", "3", "PendingStore", "PendingStore" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_MenuItemID",
                table: "OrderDetails",
                column: "MenuItemID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ebbfb39-caae-47e1-b0be-0d531475c9d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74152c16-66be-468a-97a1-83e35ca6f874");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4e1eec4-d803-43b0-9167-997607f55ec7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec2fd5d9-53cd-408b-8709-64cfd28ffa45");

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
