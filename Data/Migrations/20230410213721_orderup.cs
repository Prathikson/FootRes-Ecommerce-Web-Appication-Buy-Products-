using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Itec245_Final.Data.Migrations
{
    public partial class orderup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductsJson",
                table: "OrderHistories");

            migrationBuilder.AddColumn<int>(
                name: "OrderHistoryId",
                table: "shoes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_shoes_OrderHistoryId",
                table: "shoes",
                column: "OrderHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_shoes_OrderHistories_OrderHistoryId",
                table: "shoes",
                column: "OrderHistoryId",
                principalTable: "OrderHistories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoes_OrderHistories_OrderHistoryId",
                table: "shoes");

            migrationBuilder.DropIndex(
                name: "IX_shoes_OrderHistoryId",
                table: "shoes");

            migrationBuilder.DropColumn(
                name: "OrderHistoryId",
                table: "shoes");

            migrationBuilder.AddColumn<string>(
                name: "ProductsJson",
                table: "OrderHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
