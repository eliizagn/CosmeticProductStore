using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CosmeticProductStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedStockItemsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stock_items_stores_StoreCode1",
                table: "stock_items");

            migrationBuilder.DropIndex(
                name: "IX_stock_items_StoreCode1",
                table: "stock_items");

            migrationBuilder.DropColumn(
                name: "StoreCode1",
                table: "stock_items");

            migrationBuilder.AddForeignKey(
                name: "FK_stock_items_stores_StoreCode",
                table: "stock_items",
                column: "StoreCode",
                principalTable: "stores",
                principalColumn: "store_code",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stock_items_stores_StoreCode",
                table: "stock_items");

            migrationBuilder.AddColumn<int>(
                name: "StoreCode1",
                table: "stock_items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_stock_items_StoreCode1",
                table: "stock_items",
                column: "StoreCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_stock_items_stores_StoreCode1",
                table: "stock_items",
                column: "StoreCode1",
                principalTable: "stores",
                principalColumn: "store_code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
