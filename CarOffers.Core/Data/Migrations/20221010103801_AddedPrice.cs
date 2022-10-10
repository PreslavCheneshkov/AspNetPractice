using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarOffers.Core.Data.Migrations
{
    public partial class AddedPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Offers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Offers");
        }
    }
}
