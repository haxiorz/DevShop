using Microsoft.EntityFrameworkCore.Migrations;

namespace DevShop.Data.Migrations
{
    public partial class modelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOnLimitedSale",
                table: "Book",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRecommended",
                table: "Book",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "LimitedSalePrice",
                table: "Book",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOnLimitedSale",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "IsRecommended",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "LimitedSalePrice",
                table: "Book");
        }
    }
}
