using Microsoft.EntityFrameworkCore.Migrations;

namespace WatchSpace.Data.Migrations
{
    public partial class FiveMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefrenceNumber",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefrenceNumber",
                table: "Order");
        }
    }
}
