using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class changesincartItemsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("0bfb2c08-1abb-46d1-b5e4-ecfab67820fe"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("a190ffd2-1fb2-4de4-a2da-5b202933b83a"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("e5e47d5a-4e78-4761-b4e0-ba6cda92fc4f"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("e985f1c1-7253-46de-ab8f-4b236bb1aa41"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("f88924d3-4ec9-4e79-bb2e-6991c733d446"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("48c76cb1-5b43-476b-a69a-701a0a348f8e"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("a0e50b9c-cc68-42c1-97a1-44403d23ef9d"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Payment",
                column: "PaymentId",
                values: new object[]
                {
                    new Guid("0bfb2c08-1abb-46d1-b5e4-ecfab67820fe"),
                    new Guid("a190ffd2-1fb2-4de4-a2da-5b202933b83a")
                });

            migrationBuilder.InsertData(
                table: "ShippingMethods",
                columns: new[] { "ShippingMethodId", "Name", "price" },
                values: new object[,]
                {
                    { new Guid("e5e47d5a-4e78-4761-b4e0-ba6cda92fc4f"), "Normal Delivery", 49f },
                    { new Guid("e985f1c1-7253-46de-ab8f-4b236bb1aa41"), "Fast Delivery", 199f },
                    { new Guid("f88924d3-4ec9-4e79-bb2e-6991c733d446"), "Self pickup", 0f }
                });

            migrationBuilder.InsertData(
                table: "ShippngAddress",
                column: "ShippingAddressId",
                values: new object[]
                {
                    new Guid("48c76cb1-5b43-476b-a69a-701a0a348f8e"),
                    new Guid("a0e50b9c-cc68-42c1-97a1-44403d23ef9d")
                });
        }
    }
}
