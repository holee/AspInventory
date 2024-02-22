using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Migrations
{
    /// <inheritdoc />
    public partial class t0001001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_Customer_CustomerId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_Employee_EmployeeId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_CustomerId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_EmployeeId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_CustomerId",
                table: "orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_EmployeeId",
                table: "orders",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Customer_CustomerId",
                table: "orders",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Employee_EmployeeId",
                table: "orders",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");
        }
    }
}
