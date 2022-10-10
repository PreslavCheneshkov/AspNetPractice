using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarOffers.Core.Data.Migrations
{
    public partial class AddedMoreThings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PirctureUrl",
                table: "Offers",
                newName: "PictureUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PictureUrl",
                table: "Offers",
                newName: "PirctureUrl");
        }
    }
}
