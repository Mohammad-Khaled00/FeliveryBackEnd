using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class orderDetails : Migration
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
                    { "2fe896bc-bfae-4281-9c1c-47ddffde828e", "4", "Customer", "Customer" },
                    { "5a3daf20-fa59-40ab-a5c5-dbc0c46a3585", "2", "ApprovedStore", "ApprovedStore" },
                    { "b315df9a-5f4f-4b47-ad6b-a251385d159e", "3", "PendingStore", "PendingStore" },
                    { "f390489c-7352-4437-81f3-b278d9da373c", "1", "Admin", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_menuItemId",
                table: "OrderDetails",
                column: "menuItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

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
                    { "3de299ce-5cd9-4d75-9e83-337c8d636373", "1", "Admin", "Admin" },
                    { "5ace4706-4198-4efb-9c67-03be35bea878", "3", "PendingStore", "PendingStore" },
                    { "9a4d521a-efa9-4493-8089-955e4bbbb723", "2", "ApprovedStore", "ApprovedStore" },
                    { "a21657bf-74ff-4721-b21a-b014ae7fdfd7", "4", "Customer", "Customer" }
                });
        }
    }
}
