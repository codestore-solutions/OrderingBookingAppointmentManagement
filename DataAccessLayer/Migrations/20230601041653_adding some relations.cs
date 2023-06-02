using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addingsomerelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItemsProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems");

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

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "VarientId",
                table: "CartItems",
                newName: "ProductId");

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

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Cart",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "Cart",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems",
                columns: new[] { "CartId", "ProductId" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CartItems",
                newName: "VarientId");

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

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "CartItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Cart",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "Cart",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CartItemsProduct",
                columns: table => new
                {
                    CartItemsId = table.Column<long>(type: "bigint", nullable: false),
                    ProductsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItemsProduct", x => new { x.CartItemsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CartItemsProduct_CartItems_CartItemsId",
                        column: x => x.CartItemsId,
                        principalTable: "CartItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItemsProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItemsProduct_ProductsId",
                table: "CartItemsProduct",
                column: "ProductsId");
        }
    }
}
