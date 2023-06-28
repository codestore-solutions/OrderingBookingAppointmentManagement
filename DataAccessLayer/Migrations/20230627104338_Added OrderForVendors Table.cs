using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrderForVendorsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "orderStatus",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryCharges",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                table: "OrderItems",
                newName: "OrdersForVendorsId");

            migrationBuilder.AddColumn<int>(
                name: "orderStatus",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OrdersForVendors",
                columns: table => new
                {
                    OrdersForVendorsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<long>(type: "bigint", nullable: false),
                    DeliveryCharges = table.Column<double>(type: "float", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersForVendors", x => x.OrdersForVendorsId);
                    table.ForeignKey(
                        name: "FK_OrdersForVendors_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrdersForVendorsId",
                table: "OrderItems",
                column: "OrdersForVendorsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersForVendors_OrderId",
                table: "OrdersForVendors",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_OrdersForVendors_OrdersForVendorsId",
                table: "OrderItems",
                column: "OrdersForVendorsId",
                principalTable: "OrdersForVendors",
                principalColumn: "OrdersForVendorsId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_OrdersForVendors_OrdersForVendorsId",
                table: "OrderItems");

            migrationBuilder.DropTable(
                name: "OrdersForVendors");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrdersForVendorsId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "orderStatus",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "OrdersForVendorsId",
                table: "OrderItems",
                newName: "StoreId");

            migrationBuilder.AddColumn<int>(
                name: "orderStatus",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "DeliveryCharges",
                table: "OrderItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "OrderId",
                table: "OrderItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
