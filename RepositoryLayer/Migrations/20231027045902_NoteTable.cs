using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class NoteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoteTable",
                columns: table => new
                {
                    NoteId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Reminder = table.Column<DateTime>(nullable: true),
                    color = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    IsArchive = table.Column<bool>(nullable: false),
                    IsPin = table.Column<bool>(nullable: false),
                    IsTrash = table.Column<bool>(nullable: false),
                    Createat = table.Column<DateTime>(nullable: true),
                    Updateat = table.Column<DateTime>(nullable: true),
                    User_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteTable", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_NoteTable_User_User_Id",
                        column: x => x.User_Id,
                        principalTable: "User",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoteTable_User_Id",
                table: "NoteTable",
                column: "User_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteTable");
        }
    }
}
