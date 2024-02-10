using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Migrations
{
    /// <inheritdoc />
    public partial class _0002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SupllierRefId",
                table: "Items",
                newName: "SupplierRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryRefId",
                table: "Items",
                column: "CateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategoryRefId",
                table: "Items",
                column: "CateId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategoryRefId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CategoryRefId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "SupplierRefId",
                table: "Items",
                newName: "SupllierRefId");
        }
    }
}
