using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Migrations
{
    /// <inheritdoc />
    public partial class t3 : Migration
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemSupplier",
                table: "ItemSupplier");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "ItemSupplier",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "ItemSupplier",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Item_Id",
                table: "ItemSupplier",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Supplier_Id",
                table: "ItemSupplier",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemSupplier",
                table: "ItemSupplier",
                columns: new[] { "Item_Id", "Supplier_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_ItemSupplier_ItemId",
                table: "ItemSupplier",
                column: "ItemId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemSupplier_Items_ItemId",
                table: "ItemSupplier");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSupplier_Suppliers_SupplierId",
                table: "ItemSupplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemSupplier",
                table: "ItemSupplier");

            migrationBuilder.DropIndex(
                name: "IX_ItemSupplier_ItemId",
                table: "ItemSupplier");

            migrationBuilder.DropColumn(
                name: "Item_Id",
                table: "ItemSupplier");

            migrationBuilder.DropColumn(
                name: "Supplier_Id",
                table: "ItemSupplier");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "ItemSupplier",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "ItemSupplier",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemSupplier",
                table: "ItemSupplier",
                columns: new[] { "ItemId", "SupplierId" });

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
    }
}
