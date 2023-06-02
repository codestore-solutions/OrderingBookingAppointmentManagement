using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class changesincartItemsTable4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems");

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

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "CartItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems");

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

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CartItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems",
                columns: new[] { "CartId", "ProductId" });

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

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
