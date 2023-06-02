using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class changesincolinproducttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("6be51dbb-9856-43a8-b1ed-8dbcd7ac056c"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("a7f89a82-be9d-4e08-be74-f3cff66a5e8d"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("670a83bb-6350-4324-bf53-8bee8c081472"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("6c4f6d79-425b-41b1-aeca-887aeae925a3"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("ec82e611-00f3-4e7e-bb98-18a345d52b29"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("17d209c7-514f-417f-a81e-8ae76b1557cb"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("25e63936-3552-41bb-ac64-07e045f489cd"));

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Payment",
                column: "PaymentId",
                values: new object[]
                {
                    new Guid("a96d11a5-1a12-425e-a75f-45265ff5119e"),
                    new Guid("ff6af5e4-d066-4e11-a274-b56e6efbf6f1")
                });

            migrationBuilder.InsertData(
                table: "ShippingMethods",
                columns: new[] { "ShippingMethodId", "Name", "price" },
                values: new object[,]
                {
                    { new Guid("3496b2b8-cd51-4b4b-a7b1-29a35a8d9a97"), "Normal Delivery", 49f },
                    { new Guid("430b1b79-e7f7-4cc7-aab1-3bb7b3afe193"), "Self pickup", 0f },
                    { new Guid("801f4d22-ec9c-423d-a6df-a97967586ea5"), "Fast Delivery", 199f }
                });

            migrationBuilder.InsertData(
                table: "ShippngAddress",
                column: "ShippingAddressId",
                values: new object[]
                {
                    new Guid("05d36e1f-d0dc-4420-a2e9-7c0c8d6bdace"),
                    new Guid("49c6d4b4-6645-4d6f-a241-1917e0595a00")
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("a96d11a5-1a12-425e-a75f-45265ff5119e"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("ff6af5e4-d066-4e11-a274-b56e6efbf6f1"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("3496b2b8-cd51-4b4b-a7b1-29a35a8d9a97"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("430b1b79-e7f7-4cc7-aab1-3bb7b3afe193"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("801f4d22-ec9c-423d-a6df-a97967586ea5"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("05d36e1f-d0dc-4420-a2e9-7c0c8d6bdace"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("49c6d4b4-6645-4d6f-a241-1917e0595a00"));

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Payment",
                column: "PaymentId",
                values: new object[]
                {
                    new Guid("6be51dbb-9856-43a8-b1ed-8dbcd7ac056c"),
                    new Guid("a7f89a82-be9d-4e08-be74-f3cff66a5e8d")
                });

            migrationBuilder.InsertData(
                table: "ShippingMethods",
                columns: new[] { "ShippingMethodId", "Name", "price" },
                values: new object[,]
                {
                    { new Guid("670a83bb-6350-4324-bf53-8bee8c081472"), "Self pickup", 0f },
                    { new Guid("6c4f6d79-425b-41b1-aeca-887aeae925a3"), "Fast Delivery", 199f },
                    { new Guid("ec82e611-00f3-4e7e-bb98-18a345d52b29"), "Normal Delivery", 49f }
                });

            migrationBuilder.InsertData(
                table: "ShippngAddress",
                column: "ShippingAddressId",
                values: new object[]
                {
                    new Guid("17d209c7-514f-417f-a81e-8ae76b1557cb"),
                    new Guid("25e63936-3552-41bb-ac64-07e045f489cd")
                });
        }
    }
}
