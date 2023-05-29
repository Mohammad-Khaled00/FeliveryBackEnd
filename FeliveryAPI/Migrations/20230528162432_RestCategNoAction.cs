using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class RestCategNoAction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54d2e354-c2e0-4903-a7e2-08bc2d365420");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5dfab681-b8c5-4bd3-9351-390ea5faaf1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5ec2b0a-3cd6-40f2-8846-7a173fb4c49f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8851e28-323c-4db5-a0ce-bb96e15af24a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d019dcb-4e39-4356-8571-a3f0dccb5296", "2", "ApprovedStore", "ApprovedStore" },
                    { "51e3eb82-4498-4392-8445-2686c62cc5ae", "3", "PendingStore", "PendingStore" },
                    { "bcaddda4-db4e-41e8-933d-ee519e8e4da6", "4", "Customer", "Customer" },
                    { "f31c1718-ddb5-434b-968d-ed3b18213a21", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d019dcb-4e39-4356-8571-a3f0dccb5296");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51e3eb82-4498-4392-8445-2686c62cc5ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bcaddda4-db4e-41e8-933d-ee519e8e4da6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f31c1718-ddb5-434b-968d-ed3b18213a21");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54d2e354-c2e0-4903-a7e2-08bc2d365420", "4", "Customer", "Customer" },
                    { "5dfab681-b8c5-4bd3-9351-390ea5faaf1a", "3", "PendingStore", "PendingStore" },
                    { "c5ec2b0a-3cd6-40f2-8846-7a173fb4c49f", "2", "ApprovedStore", "ApprovedStore" },
                    { "e8851e28-323c-4db5-a0ce-bb96e15af24a", "1", "Admin", "Admin" }
                });
        }
    }
}
