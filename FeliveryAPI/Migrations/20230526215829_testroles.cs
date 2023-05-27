using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class testroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0932e853-2f2e-4b0b-946f-8846740faae2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0db3ace6-b5f7-49a5-b4c1-cfa95adc8490");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33eaaf24-1254-4dfd-8a41-c253927f9398");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a0aac5d-1fc5-4e02-a0e9-bb4afdab53c4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0932e853-2f2e-4b0b-946f-8846740faae2", "2", "ApprovedStore", "ApprovedStore" },
                    { "0db3ace6-b5f7-49a5-b4c1-cfa95adc8490", "4", "Customer", "Customer" },
                    { "33eaaf24-1254-4dfd-8a41-c253927f9398", "3", "PendingStore", "PendingStore" },
                    { "6a0aac5d-1fc5-4e02-a0e9-bb4afdab53c4", "1", "Admin", "Admin" }
                });
        }
    }
}
