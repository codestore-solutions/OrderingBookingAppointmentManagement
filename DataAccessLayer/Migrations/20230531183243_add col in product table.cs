using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addcolinproducttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("559f5b3e-c39f-4f6d-bf0d-8793af846ffb"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("9eb0679f-f8b2-4c96-a8d7-d1ce24930f2b"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("154e55ed-524f-4783-83c2-b3ed730ac270"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("797e11f9-d2d9-44e6-b6ba-ba0edb928d78"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("e1c6f8e1-8453-4a1a-88c4-05a8743dc049"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("a886284b-48aa-42de-aa15-6f1c3a08ee55"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("f4ccd450-780f-4205-9dc0-62e5aca90b0b"));

            migrationBuilder.DropColumn(
                name: "ProductQuantity",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductQuantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Payment",
                column: "PaymentId",
                values: new object[]
                {
                    new Guid("559f5b3e-c39f-4f6d-bf0d-8793af846ffb"),
                    new Guid("9eb0679f-f8b2-4c96-a8d7-d1ce24930f2b")
                });

            migrationBuilder.InsertData(
                table: "ShippingMethods",
                columns: new[] { "ShippingMethodId", "Name", "price" },
                values: new object[,]
                {
                    { new Guid("154e55ed-524f-4783-83c2-b3ed730ac270"), "Fast Delivery", 199f },
                    { new Guid("797e11f9-d2d9-44e6-b6ba-ba0edb928d78"), "Normal Delivery", 49f },
                    { new Guid("e1c6f8e1-8453-4a1a-88c4-05a8743dc049"), "Self pickup", 0f }
                });

            migrationBuilder.InsertData(
                table: "ShippngAddress",
                column: "ShippingAddressId",
                values: new object[]
                {
                    new Guid("a886284b-48aa-42de-aa15-6f1c3a08ee55"),
                    new Guid("f4ccd450-780f-4205-9dc0-62e5aca90b0b")
                });
        }
    }
}
