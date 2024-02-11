using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Migrations
{
    /// <inheritdoc />
    public partial class test03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CateId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CateId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CateId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "cat_id",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_cat_id",
                table: "Items",
                column: "cat_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_cat_id",
                table: "Items",
                column: "cat_id",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_cat_id",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_cat_id",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "cat_id",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "CateId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_CateId",
                table: "Items",
                column: "CateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CateId",
                table: "Items",
                column: "CateId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
