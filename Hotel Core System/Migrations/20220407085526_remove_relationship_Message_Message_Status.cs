using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Core_System.Migrations
{
    public partial class remove_relationship_Message_Message_Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageStatuses_Messages_MessageId",
                table: "MessageStatuses");

            migrationBuilder.AlterColumn<int>(
                name: "MessageId",
                table: "MessageStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageStatuses_Messages_MessageId",
                table: "MessageStatuses",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageStatuses_Messages_MessageId",
                table: "MessageStatuses");

            migrationBuilder.AlterColumn<int>(
                name: "MessageId",
                table: "MessageStatuses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageStatuses_Messages_MessageId",
                table: "MessageStatuses",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
