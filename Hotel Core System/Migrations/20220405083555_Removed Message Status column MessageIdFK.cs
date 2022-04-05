using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Core_System.Migrations
{
    public partial class RemovedMessageStatuscolumnMessageIdFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageIdFK",
                table: "MessageStatuses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MessageIdFK",
                table: "MessageStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
