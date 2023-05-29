using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class changenames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("313d6fe1-0cb0-47d7-83df-e44802c4d392"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("32ae8b46-49e0-49aa-a335-677cd0d699b7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("6ee21223-f486-4a8d-9446-ec6792b8d439"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("efe640a6-39c7-40ce-b7f1-ed24d37dea0b"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("2d21930f-f418-4e4b-acdc-b90cddcf2d0f"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("c2335dc0-5d37-46e3-979f-13951f814d4b"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("c94bcad8-4825-4016-a48d-70c56346e558"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("488f4dfb-aa3b-4b55-9b91-be558a02d0fa"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("68dbd37c-ea65-48c8-95e3-ad8dd948cb8a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("8a871cc3-df68-49b6-b0d9-5a70d3f2111c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("931a9eaa-1080-4b88-aa8d-46d394086caa"));

            migrationBuilder.RenameColumn(
                name: "WishListId",
                table: "Wishlists",
                newName: "Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Wishlists",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Payment",
                column: "PaymentId",
                values: new object[]
                {
                    new Guid("79cfae30-87cc-46b0-a89c-32c198631c70"),
                    new Guid("81bc3942-83b1-4282-9e72-4f0c999a3a85")
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "OrderLineItemsId", "ProductPrice", "ProductQuantity" },
                values: new object[,]
                {
                    { new Guid("d17aa43f-f3f5-4608-afcb-676934e24eb6"), new Guid("1ab5c72a-b269-492b-83b7-d216dafd18fe"), 24999f, 1 },
                    { new Guid("d9252eae-e632-41d5-b514-538ade203252"), new Guid("7f03c2e7-47b5-4ff0-a685-8e63f4ffc910"), 9999f, 1 }
                });

            migrationBuilder.InsertData(
                table: "ShippingMethods",
                columns: new[] { "ShippingMethodId", "Name", "price" },
                values: new object[,]
                {
                    { new Guid("17190837-8f82-4e31-870a-d12c6c091766"), "Self pickup", 0f },
                    { new Guid("50860922-b382-4e1d-955b-ba2c4a1ce73b"), "Fast Delivery", 199f },
                    { new Guid("704e504a-7798-4cfd-9d4a-eb33fe65e3a8"), "Normal Delivery", 49f }
                });

            migrationBuilder.InsertData(
                table: "ShippngAddress",
                column: "ShippingAddressId",
                values: new object[]
                {
                    new Guid("58cfcf45-6ff3-4115-a651-c68bffa9cb44"),
                    new Guid("d6b3ae4b-095e-4909-912b-d2ef09591af8")
                });

            migrationBuilder.InsertData(
                table: "User",
                column: "UserId",
                values: new object[]
                {
                    new Guid("8a614a91-cca1-4584-a66d-daf79789243a"),
                    new Guid("d6c496a9-783f-4beb-a619-578b78d3b9ee")
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("79cfae30-87cc-46b0-a89c-32c198631c70"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("81bc3942-83b1-4282-9e72-4f0c999a3a85"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d17aa43f-f3f5-4608-afcb-676934e24eb6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d9252eae-e632-41d5-b514-538ade203252"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("17190837-8f82-4e31-870a-d12c6c091766"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("50860922-b382-4e1d-955b-ba2c4a1ce73b"));

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodId",
                keyValue: new Guid("704e504a-7798-4cfd-9d4a-eb33fe65e3a8"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("58cfcf45-6ff3-4115-a651-c68bffa9cb44"));

            migrationBuilder.DeleteData(
                table: "ShippngAddress",
                keyColumn: "ShippingAddressId",
                keyValue: new Guid("d6b3ae4b-095e-4909-912b-d2ef09591af8"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("8a614a91-cca1-4584-a66d-daf79789243a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("d6c496a9-783f-4beb-a619-578b78d3b9ee"));

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Wishlists",
                newName: "WishListId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Wishlists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Payment",
                column: "PaymentId",
                values: new object[]
                {
                    new Guid("313d6fe1-0cb0-47d7-83df-e44802c4d392"),
                    new Guid("32ae8b46-49e0-49aa-a335-677cd0d699b7")
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "OrderLineItemsId", "ProductPrice", "ProductQuantity" },
                values: new object[,]
                {
                    { new Guid("6ee21223-f486-4a8d-9446-ec6792b8d439"), new Guid("c9cb52b8-d155-4125-a504-5b31a60b0c63"), 24999f, 1 },
                    { new Guid("efe640a6-39c7-40ce-b7f1-ed24d37dea0b"), new Guid("eaf6ec93-2abe-4df1-964f-c57614b33c94"), 9999f, 1 }
                });

            migrationBuilder.InsertData(
                table: "ShippingMethods",
                columns: new[] { "ShippingMethodId", "Name", "price" },
                values: new object[,]
                {
                    { new Guid("2d21930f-f418-4e4b-acdc-b90cddcf2d0f"), "Self pickup", 0f },
                    { new Guid("c2335dc0-5d37-46e3-979f-13951f814d4b"), "Normal Delivery", 49f },
                    { new Guid("c94bcad8-4825-4016-a48d-70c56346e558"), "Fast Delivery", 199f }
                });

            migrationBuilder.InsertData(
                table: "ShippngAddress",
                column: "ShippingAddressId",
                values: new object[]
                {
                    new Guid("488f4dfb-aa3b-4b55-9b91-be558a02d0fa"),
                    new Guid("68dbd37c-ea65-48c8-95e3-ad8dd948cb8a")
                });

            migrationBuilder.InsertData(
                table: "User",
                column: "UserId",
                values: new object[]
                {
                    new Guid("8a871cc3-df68-49b6-b0d9-5a70d3f2111c"),
                    new Guid("931a9eaa-1080-4b88-aa8d-46d394086caa")
                });
        }
    }
}
