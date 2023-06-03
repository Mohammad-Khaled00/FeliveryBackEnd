using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class FeedBacks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fe01f93-f4c1-4987-b102-e8e5d90aef85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d2611ae-b5a4-4954-a6a3-ac22bfe68e03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2fb189c-8324-40d5-8312-ed6658edd764");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4d6b16f-b99d-435f-9bd4-39dd7bfafd25");

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Restaurants_RestaurantID",
                        column: x => x.RestaurantID,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalFeedBack",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalFeedBack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalFeedBack_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechnicalFeedBack_Restaurants_RestaurantID",
                        column: x => x.RestaurantID,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e878532-f0fd-4462-8429-5413a3165e9c", "4", "Customer", "Customer" },
                    { "5ce525cd-c814-434c-aafd-0393cf58773e", "1", "Admin", "Admin" },
                    { "7d9d9582-ecd4-4d8f-b7c9-ceea4fa19095", "3", "PendingStore", "PendingStore" },
                    { "931aa61f-9f8e-48c1-9ecc-204e1a6d7e46", "2", "ApprovedStore", "ApprovedStore" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_CustomerID",
                table: "Review",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_RestaurantID",
                table: "Review",
                column: "RestaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalFeedBack_CustomerID",
                table: "TechnicalFeedBack",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalFeedBack_RestaurantID",
                table: "TechnicalFeedBack",
                column: "RestaurantID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "TechnicalFeedBack");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e878532-f0fd-4462-8429-5413a3165e9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ce525cd-c814-434c-aafd-0393cf58773e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d9d9582-ecd4-4d8f-b7c9-ceea4fa19095");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "931aa61f-9f8e-48c1-9ecc-204e1a6d7e46");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4fe01f93-f4c1-4987-b102-e8e5d90aef85", "2", "ApprovedStore", "ApprovedStore" },
                    { "9d2611ae-b5a4-4954-a6a3-ac22bfe68e03", "3", "PendingStore", "PendingStore" },
                    { "e2fb189c-8324-40d5-8312-ed6658edd764", "1", "Admin", "Admin" },
                    { "e4d6b16f-b99d-435f-9bd4-39dd7bfafd25", "4", "Customer", "Customer" }
                });
        }
    }
}
