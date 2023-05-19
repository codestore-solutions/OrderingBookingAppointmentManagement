using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    OrderLineItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductPrice = table.Column<double>(type: "float", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.OrderLineItemsId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderAmount = table.Column<float>(type: "real", nullable: false),
                    OrderQty = table.Column<int>(type: "int", nullable: false),
                    OrderLineItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShippingMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShippingAddressID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderLineItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductPrice = table.Column<float>(type: "real", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "ShippingMethods",
                columns: table => new
                {
                    ShippingMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethods", x => x.ShippingMethodId);
                });

            migrationBuilder.CreateTable(
                name: "ShippngAddress",
                columns: table => new
                {
                    ShippingAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippngAddress", x => x.ShippingAddressId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    WishListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.WishListId);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShippingMethods");

            migrationBuilder.DropTable(
                name: "ShippngAddress");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Wishlists");
        }
    }
}
