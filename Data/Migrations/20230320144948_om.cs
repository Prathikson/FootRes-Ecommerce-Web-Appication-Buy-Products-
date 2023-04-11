using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Itec245_Final.Data.Migrations
{
    public partial class om : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "shoes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "shoes");
        }
    }
}
