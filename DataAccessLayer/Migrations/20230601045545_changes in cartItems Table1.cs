using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class changesincartItemsTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("ac26126e-aa4f-4ec9-8c5e-34d22a67caba"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("e4ef4663-943c-4998-9f3e-e2c319932c6e"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("8ec5ee8f-7d66-44aa-9581-a618defe7b53"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("a7183456-f111-4218-ad90-26649301ed45"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("c28aa430-e801-4102-8a69-c7981f2e5896"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("4bea7dc4-4975-4ae6-9a39-5067261a90e0"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("6f353eec-986b-4cec-b911-27c6649ba945"));

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Cart");

            migrationBuilder.InsertData(
                table: "Payment",
                column: "PaymentId",
                values: new object[]
                {
                    new Guid("10b26182-149c-4430-8f39-4051e2c6758f"),
                    new Guid("62981e9a-643e-4ecc-a9f9-f2ad8baaea43")
                });

            migrationBuilder.InsertData(
                table: "ShippingMethods",
                columns: new[] { "ShippingMethodId", "Name", "price" },
                values: new object[,]
                {
                    { new Guid("08a68017-3d55-4af2-b7a7-729113a08343"), "Normal Delivery", 49f },
                    { new Guid("91417fbc-13c0-40de-a621-ce4f79ed7260"), "Fast Delivery", 199f },
                    { new Guid("b9a04ee9-9a0e-4620-9eca-99cb892f7676"), "Self pickup", 0f }
                });

            migrationBuilder.InsertData(
                table: "ShippngAddress",
                column: "ShippingAddressId",
                values: new object[]
                {
                    new Guid("12e7c4a8-d6a2-47eb-b353-abed60d81f79"),
                    new Guid("2e446c42-c187-457c-a3cd-1cb5d03b8123")
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("10b26182-149c-4430-8f39-4051e2c6758f"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("62981e9a-643e-4ecc-a9f9-f2ad8baaea43"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("08a68017-3d55-4af2-b7a7-729113a08343"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("91417fbc-13c0-40de-a621-ce4f79ed7260"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("b9a04ee9-9a0e-4620-9eca-99cb892f7676"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("12e7c4a8-d6a2-47eb-b353-abed60d81f79"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("2e446c42-c187-457c-a3cd-1cb5d03b8123"));

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "Cart",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Cart",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Payment",
                column: "PaymentId",
                values: new object[]
                {
                    new Guid("ac26126e-aa4f-4ec9-8c5e-34d22a67caba"),
                    new Guid("e4ef4663-943c-4998-9f3e-e2c319932c6e")
                });

            migrationBuilder.InsertData(
                table: "ShippingMethods",
                columns: new[] { "ShippingMethodId", "Name", "price" },
                values: new object[,]
                {
                    { new Guid("8ec5ee8f-7d66-44aa-9581-a618defe7b53"), "Self pickup", 0f },
                    { new Guid("a7183456-f111-4218-ad90-26649301ed45"), "Normal Delivery", 49f },
                    { new Guid("c28aa430-e801-4102-8a69-c7981f2e5896"), "Fast Delivery", 199f }
                });

            migrationBuilder.InsertData(
                table: "ShippngAddress",
                column: "ShippingAddressId",
                values: new object[]
                {
                    new Guid("4bea7dc4-4975-4ae6-9a39-5067261a90e0"),
                    new Guid("6f353eec-986b-4cec-b911-27c6649ba945")
                });
        }
    }
}
