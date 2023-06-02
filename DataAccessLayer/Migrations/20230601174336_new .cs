using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("127bf165-6891-4e0d-b416-798324af7f77"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("2aca555a-f357-40ae-baa5-d19e6f80d5cc"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("2b2d73e7-88e8-4d8c-b023-c92ecc0d02ab"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("9ac74455-acf2-4360-ae02-641ca2793ff2"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("becb3cfc-de94-4b8e-b658-c87d450e937f"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("620ff580-53b6-4810-ae3a-a1753c4835f7"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("d2ae67a9-ff28-4df1-a234-37f1240b07af"));

            migrationBuilder.InsertData(
                table: "Payment",
                column: "PaymentId",
                values: new object[]
                {
                    new Guid("2e85207d-55f8-444f-9842-5dd188d47d2b"),
                    new Guid("45220067-5341-4886-ab66-c5926721cd77")
                });

            migrationBuilder.InsertData(
                table: "ShippingMethods",
                columns: new[] { "ShippingMethodId", "Name", "price" },
                values: new object[,]
                {
                    { new Guid("99b90810-1ee4-4c99-a1e8-2ee5f5885821"), "Self pickup", 0f },
                    { new Guid("9ca051b1-1cc8-4af1-a411-4fe0f1d44c19"), "Normal Delivery", 49f },
                    { new Guid("9ef8575e-70a1-4605-b35f-7b90ef55c17f"), "Fast Delivery", 199f }
                });

            migrationBuilder.InsertData(
                table: "ShippngAddress",
                column: "ShippingAddressId",
                values: new object[]
                {
                    new Guid("27b65daa-265e-48fa-aedf-4d863ea27d61"),
                    new Guid("b473110d-d8a0-409d-9c37-47ab6df1ed11")
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("2e85207d-55f8-444f-9842-5dd188d47d2b"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("45220067-5341-4886-ab66-c5926721cd77"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("99b90810-1ee4-4c99-a1e8-2ee5f5885821"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("9ca051b1-1cc8-4af1-a411-4fe0f1d44c19"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("9ef8575e-70a1-4605-b35f-7b90ef55c17f"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("27b65daa-265e-48fa-aedf-4d863ea27d61"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("b473110d-d8a0-409d-9c37-47ab6df1ed11"));

            migrationBuilder.InsertData(
                table: "Payment",
                column: "PaymentId",
                values: new object[]
                {
                    new Guid("127bf165-6891-4e0d-b416-798324af7f77"),
                    new Guid("2aca555a-f357-40ae-baa5-d19e6f80d5cc")
                });

            migrationBuilder.InsertData(
                table: "ShippingMethods",
                columns: new[] { "ShippingMethodId", "Name", "price" },
                values: new object[,]
                {
                    { new Guid("2b2d73e7-88e8-4d8c-b023-c92ecc0d02ab"), "Normal Delivery", 49f },
                    { new Guid("9ac74455-acf2-4360-ae02-641ca2793ff2"), "Fast Delivery", 199f },
                    { new Guid("becb3cfc-de94-4b8e-b658-c87d450e937f"), "Self pickup", 0f }
                });

            migrationBuilder.InsertData(
                table: "ShippngAddress",
                column: "ShippingAddressId",
                values: new object[]
                {
                    new Guid("620ff580-53b6-4810-ae3a-a1753c4835f7"),
                    new Guid("d2ae67a9-ff28-4df1-a234-37f1240b07af")
                });
        }
    }
}
