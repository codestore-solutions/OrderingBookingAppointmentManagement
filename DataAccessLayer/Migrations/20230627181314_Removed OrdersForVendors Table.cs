using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class RemovedOrdersForVendorsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_OrdersForVendors_OrdersForVendorsId",
                table: "OrderItems");

            migrationBuilder.DropTable(
                name: "OrdersForVendors");

            migrationBuilder.RenameColumn(
                name: "OrdersForVendorsId",
                table: "OrderItems",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrdersForVendorsId",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderId");

            migrationBuilder.AddColumn<double>(
                name: "DeliveryCharges",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "VendorId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "DeliveryCharges",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderItems",
                newName: "OrdersForVendorsId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                newName: "IX_OrderItems_OrdersForVendorsId");

            migrationBuilder.CreateTable(
                name: "OrdersForVendors",
                columns: table => new
                {
                    OrdersForVendorsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    DeliveryCharges = table.Column<double>(type: "float", nullable: false),
                    VendorId = table.Column<long>(type: "bigint", nullable: false)
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
    }
}
