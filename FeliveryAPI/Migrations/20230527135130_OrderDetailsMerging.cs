using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class OrderDetailsMerging : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4444bacf-9920-485c-af6e-5310836c2640");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "883d7674-084e-4516-bd43-facb3f6ec51a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad83b4ac-ff00-4cee-a5cd-77709f21ea50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9bd0502-5d0c-4241-baf7-709a985ee9e8");

            migrationBuilder.RenameColumn(
                name: "offerPrice",
                table: "Offers",
                newName: "OfferPrice");

            migrationBuilder.RenameColumn(
                name: "offerImg",
                table: "Offers",
                newName: "OfferImg");

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    MenuItemID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
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
                    { "030c048a-f56d-4b3f-8aaa-d6f9f65cad31", "2", "ApprovedStore", "ApprovedStore" },
                    { "03f126e8-08c4-4de5-9d52-a198a3a04b16", "3", "PendingStore", "PendingStore" },
                    { "4c8c5bfc-9a31-4141-b4b2-021ae8648946", "4", "Customer", "Customer" },
                    { "ee1b9797-e000-4e4b-9d4c-b3b17fcd5b0d", "1", "Admin", "Admin" }
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
                keyValue: "030c048a-f56d-4b3f-8aaa-d6f9f65cad31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f126e8-08c4-4de5-9d52-a198a3a04b16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c8c5bfc-9a31-4141-b4b2-021ae8648946");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee1b9797-e000-4e4b-9d4c-b3b17fcd5b0d");

            migrationBuilder.RenameColumn(
                name: "OfferPrice",
                table: "Offers",
                newName: "offerPrice");

            migrationBuilder.RenameColumn(
                name: "OfferImg",
                table: "Offers",
                newName: "offerImg");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4444bacf-9920-485c-af6e-5310836c2640", "4", "Customer", "Customer" },
                    { "883d7674-084e-4516-bd43-facb3f6ec51a", "3", "PendingStore", "PendingStore" },
                    { "ad83b4ac-ff00-4cee-a5cd-77709f21ea50", "2", "ApprovedStore", "ApprovedStore" },
                    { "c9bd0502-5d0c-4241-baf7-709a985ee9e8", "1", "Admin", "Admin" }
                });
        }
    }
}
