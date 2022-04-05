using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Core_System.Migrations
{
    public partial class MessagesandMessageStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message_txt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recipient = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message_Status_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageId = table.Column<int>(type: "int", nullable: true),
                    MessageIdFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageStatuses_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageStatuses_MessageId",
                table: "MessageStatuses",
                column: "MessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageStatuses");

            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
