using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class changesincartItemsTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Payment",
                column: "PaymentId",
                values: new object[]
                {
                    new Guid("06a8c8ab-5dab-49b1-b8d7-3492d89237b9"),
                    new Guid("69c2f708-bdc4-4e46-bae6-8b0d41247baf")
                });

            migrationBuilder.InsertData(
                table: "ShippingMethods",
                columns: new[] { "ShippingMethodId", "Name", "price" },
                values: new object[,]
                {
                    { new Guid("5c03a0fa-87fa-4e2e-9b43-4dcbbff7190b"), "Normal Delivery", 49f },
                    { new Guid("66d38024-5306-41eb-95f3-bd2fc7890875"), "Fast Delivery", 199f },
                    { new Guid("a100fc2c-b3be-4482-a38f-ba65d948813b"), "Self pickup", 0f }
                });

            migrationBuilder.InsertData(
                table: "ShippngAddress",
                column: "ShippingAddressId",
                values: new object[]
                {
                    new Guid("4438ee3a-0b97-44a0-834b-edd2c24c5d84"),
                    new Guid("6e009124-7a40-4391-ade7-77520d46ef5d")
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("06a8c8ab-5dab-49b1-b8d7-3492d89237b9"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("69c2f708-bdc4-4e46-bae6-8b0d41247baf"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("5c03a0fa-87fa-4e2e-9b43-4dcbbff7190b"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("66d38024-5306-41eb-95f3-bd2fc7890875"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("a100fc2c-b3be-4482-a38f-ba65d948813b"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("4438ee3a-0b97-44a0-834b-edd2c24c5d84"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("6e009124-7a40-4391-ade7-77520d46ef5d"));

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
