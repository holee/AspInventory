using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Migrations
{
    /// <inheritdoc />
    public partial class t4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemSupplier_Items_ItemId",
                table: "ItemSupplier");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSupplier_Suppliers_SupplierId",
                table: "ItemSupplier");

            migrationBuilder.DropIndex(
                name: "IX_ItemSupplier_ItemId",
                table: "ItemSupplier");

            migrationBuilder.DropIndex(
                name: "IX_ItemSupplier_SupplierId",
                table: "ItemSupplier");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ItemSupplier");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "ItemSupplier");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSupplier_Supplier_Id",
                table: "ItemSupplier",
                column: "Supplier_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSupplier_Items_Item_Id",
                table: "ItemSupplier",
                column: "Item_Id",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSupplier_Suppliers_Supplier_Id",
                table: "ItemSupplier",
                column: "Supplier_Id",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemSupplier_Items_Item_Id",
                table: "ItemSupplier");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSupplier_Suppliers_Supplier_Id",
                table: "ItemSupplier");

            migrationBuilder.DropIndex(
                name: "IX_ItemSupplier_Supplier_Id",
                table: "ItemSupplier");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "ItemSupplier",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "ItemSupplier",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemSupplier_ItemId",
                table: "ItemSupplier",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSupplier_SupplierId",
                table: "ItemSupplier",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSupplier_Items_ItemId",
                table: "ItemSupplier",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSupplier_Suppliers_SupplierId",
                table: "ItemSupplier",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }
    }
}
