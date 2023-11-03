using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class CollaboratorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollaboratorTable",
                columns: table => new
                {
                    Collaborator_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    collaborator_Email = table.Column<string>(nullable: true),
                    User_Id = table.Column<int>(nullable: false),
                    NoteId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaboratorTable", x => x.Collaborator_ID);
                    table.ForeignKey(
                        name: "FK_CollaboratorTable_NoteTable_NoteId",
                        column: x => x.NoteId,
                        principalTable: "NoteTable",
                        principalColumn: "NoteId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CollaboratorTable_User_User_Id",
                        column: x => x.User_Id,
                        principalTable: "User",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorTable_NoteId",
                table: "CollaboratorTable",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorTable_User_Id",
                table: "CollaboratorTable",
                column: "User_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollaboratorTable");
        }
    }
}
