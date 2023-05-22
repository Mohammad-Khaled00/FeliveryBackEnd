using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class offers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Orders_OrderId",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Offers",
                newName: "RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_OrderId",
                table: "Offers",
                newName: "IX_Offers_RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Restaurants_RestaurantId",
                table: "Offers",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Restaurants_RestaurantId",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "Offers",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_RestaurantId",
                table: "Offers",
                newName: "IX_Offers_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Orders_OrderId",
                table: "Offers",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
