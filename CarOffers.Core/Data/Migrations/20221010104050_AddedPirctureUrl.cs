using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarOffers.Core.Data.Migrations
{
    public partial class AddedPirctureUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PirctureUrl",
                table: "Offers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PirctureUrl",
                table: "Offers");
        }
    }
}
