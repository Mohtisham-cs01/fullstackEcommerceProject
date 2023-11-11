using Microsoft.EntityFrameworkCore.Migrations;

namespace WatchSpace.Data.Migrations
{
    public partial class Seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Original_Price",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sale_Price",
                table: "Order",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Original_Price",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Sale_Price",
                table: "Order");
        }
    }
}
