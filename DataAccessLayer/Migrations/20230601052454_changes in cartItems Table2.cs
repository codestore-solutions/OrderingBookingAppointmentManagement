using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class changesincartItemsTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Payment",
                column: "PaymentId",
                values: new object[]
                {
                    new Guid("285f7625-f81e-4e61-9463-d8ca1be8660f"),
                    new Guid("fe9908d1-7684-4ad7-a225-0af3eee39e00")
                });

            migrationBuilder.InsertData(
                table: "ShippingMethods",
                columns: new[] { "ShippingMethodId", "Name", "price" },
                values: new object[,]
                {
                    { new Guid("29933aa2-4bd6-4061-b3ef-5cdf4c1d7ef6"), "Normal Delivery", 49f },
                    { new Guid("41ace760-0406-47ce-99b6-e739c3db889f"), "Fast Delivery", 199f },
                    { new Guid("fc326abe-79a0-42c2-b864-948e8c6140ad"), "Self pickup", 0f }
                });

            migrationBuilder.InsertData(
                table: "ShippngAddress",
                column: "ShippingAddressId",
                values: new object[]
                {
                    new Guid("75840331-e2f4-4001-b068-dfdf849e13e1"),
                    new Guid("d3fa79f9-7a28-4819-8a22-11f9fd5346e3")
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("285f7625-f81e-4e61-9463-d8ca1be8660f"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("fe9908d1-7684-4ad7-a225-0af3eee39e00"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("29933aa2-4bd6-4061-b3ef-5cdf4c1d7ef6"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("41ace760-0406-47ce-99b6-e739c3db889f"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("fc326abe-79a0-42c2-b864-948e8c6140ad"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("75840331-e2f4-4001-b068-dfdf849e13e1"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("d3fa79f9-7a28-4819-8a22-11f9fd5346e3"));

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
    }
}
