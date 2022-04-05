using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Core_System.Migrations
{
    public partial class Addimage_urlcolumninuserstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "img_url",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img_url",
                table: "AspNetUsers");
        }
    }
}
