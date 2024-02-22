using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Migrations
{
    /// <inheritdoc />
    public partial class t2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemSupplier_Items_SupId",
                table: "ItemSupplier");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSupplier_Suppliers_ItemId",
                table: "ItemSupplier");

            migrationBuilder.RenameColumn(
                name: "SupId",
                table: "ItemSupplier",
                newName: "SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemSupplier_SupId",
                table: "ItemSupplier",
                newName: "IX_ItemSupplier_SupplierId");

            migrationBuilder.AddColumn<string>(
                name: "Desctiption",
                table: "ItemSupplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSupplier_Items_ItemId",
                table: "ItemSupplier",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSupplier_Suppliers_SupplierId",
                table: "ItemSupplier",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemSupplier_Items_ItemId",
                table: "ItemSupplier");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSupplier_Suppliers_SupplierId",
                table: "ItemSupplier");

            migrationBuilder.DropColumn(
                name: "Desctiption",
                table: "ItemSupplier");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "ItemSupplier",
                newName: "SupId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemSupplier_SupplierId",
                table: "ItemSupplier",
                newName: "IX_ItemSupplier_SupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSupplier_Items_SupId",
                table: "ItemSupplier",
                column: "SupId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSupplier_Suppliers_ItemId",
                table: "ItemSupplier",
                column: "ItemId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
