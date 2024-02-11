using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Migrations
{
    /// <inheritdoc />
    public partial class test06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_catId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "catId",
                table: "Items",
                newName: "cid");

            migrationBuilder.RenameIndex(
                name: "IX_Items_catId",
                table: "Items",
                newName: "IX_Items_cid");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_cid",
                table: "Items",
                column: "cid",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_cid",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CategoryId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "cid",
                table: "Items",
                newName: "catId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_cid",
                table: "Items",
                newName: "IX_Items_catId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_catId",
                table: "Items",
                column: "catId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
