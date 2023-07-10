using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Addednewcolumninaddresstableandremovedshippingaddresstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_ShippngAddress_ShippingAddressId",
                table: "Addresses");

            migrationBuilder.DropTable(
                name: "ShippngAddress");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ShippingAddressId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ShippingAddressId",
                table: "Addresses",
                newName: "UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "CartItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressType",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AddressType",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Addresses",
                newName: "ShippingAddressId");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "CartItems",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateTable(
                name: "ShippngAddress",
                columns: table => new
                {
                    ShippingAddressId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippngAddress", x => x.ShippingAddressId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ShippingAddressId",
                table: "Addresses",
                column: "ShippingAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_ShippngAddress_ShippingAddressId",
                table: "Addresses",
                column: "ShippingAddressId",
                principalTable: "ShippngAddress",
                principalColumn: "ShippingAddressId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
