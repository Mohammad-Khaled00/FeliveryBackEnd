using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class Linking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SecurityID",
                table: "Restaurants",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_SecurityID",
                table: "Restaurants",
                column: "SecurityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_AspNetUsers_SecurityID",
                table: "Restaurants",
                column: "SecurityID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_AspNetUsers_SecurityID",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_SecurityID",
                table: "Restaurants");

            migrationBuilder.AlterColumn<string>(
                name: "SecurityID",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
