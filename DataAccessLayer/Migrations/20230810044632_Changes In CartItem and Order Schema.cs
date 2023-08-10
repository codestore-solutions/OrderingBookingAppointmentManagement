using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class ChangesInCartItemandOrderSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Cart_CartId",
                table: "CartItems");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "DeliverySlot",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "VarientId",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "orderStatus",
                table: "OrderItems",
                newName: "OrderStatus");

            migrationBuilder.RenameColumn(
                name: "VarientId",
                table: "OrderItems",
                newName: "VariantId");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "CartItems",
                newName: "VariantId");

            migrationBuilder.AddColumn<long>(
                name: "DeliverySlotId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "CartItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "CartItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliverySlotId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                table: "OrderItems",
                newName: "orderStatus");

            migrationBuilder.RenameColumn(
                name: "VariantId",
                table: "OrderItems",
                newName: "VarientId");

            migrationBuilder.RenameColumn(
                name: "VariantId",
                table: "CartItems",
                newName: "CartId");

            migrationBuilder.AddColumn<int>(
                name: "DeliverySlot",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "Quantity",
                table: "CartItems",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<long>(
                name: "VarientId",
                table: "CartItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Cart_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
