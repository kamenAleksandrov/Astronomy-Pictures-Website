using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net_Tutorial_Website.Migrations
{
    public partial class ImageDataToImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageData",
                table: "Movie",
                newName: "ImagePath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Movie",
                newName: "ImageData");
        }
    }
}
