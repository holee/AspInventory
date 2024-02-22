using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Migrations
{
    /// <inheritdoc />
    public partial class t000100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "SupplierRefId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerRefId = table.Column<int>(type: "int", nullable: false),
                    EmployeeRefId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_orders_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_orders_Customer_CustomerRefId",
                        column: x => x.CustomerRefId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_orders_Employee_EmployeeRefId",
                        column: x => x.EmployeeRefId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLine",
                columns: table => new
                {
                    OrderLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderRefId = table.Column<int>(type: "int", nullable: false),
                    ItemRefId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLine", x => x.OrderLineId);
                    table.ForeignKey(
                        name: "FK_OrderLine_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderLine_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemSupplier_ItemId",
                table: "ItemSupplier",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSupplier_SupplierId",
                table: "ItemSupplier",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SupplierRefId",
                table: "Items",
                column: "SupplierRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ItemId",
                table: "Customer",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_ItemId",
                table: "OrderLine",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_OrderId",
                table: "OrderLine",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_CustomerId",
                table: "orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_CustomerRefId",
                table: "orders",
                column: "CustomerRefId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_EmployeeId",
                table: "orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_EmployeeRefId",
                table: "orders",
                column: "EmployeeRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Suppliers_SupplierRefId",
                table: "Items",
                column: "SupplierRefId",
                principalTable: "Suppliers",
                principalColumn: "Id");

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
                name: "FK_Items_Suppliers_SupplierRefId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSupplier_Items_ItemId",
                table: "ItemSupplier");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSupplier_Suppliers_SupplierId",
                table: "ItemSupplier");

            migrationBuilder.DropTable(
                name: "OrderLine");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_ItemSupplier_ItemId",
                table: "ItemSupplier");

            migrationBuilder.DropIndex(
                name: "IX_ItemSupplier_SupplierId",
                table: "ItemSupplier");

            migrationBuilder.DropIndex(
                name: "IX_Items_SupplierRefId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ItemSupplier");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "ItemSupplier");

            migrationBuilder.DropColumn(
                name: "SupplierRefId",
                table: "Items");

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
    }
}
