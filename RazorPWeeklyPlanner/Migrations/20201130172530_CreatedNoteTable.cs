using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPWeeklyPlanner.Migrations
{
    public partial class CreatedNoteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    NoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotesColourCategoryId = table.Column<int>(type: "int", nullable: false),
                    WeekDayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_Note_NoteColourCategory_NotesColourCategoryId",
                        column: x => x.NotesColourCategoryId,
                        principalTable: "NoteColourCategory",
                        principalColumn: "NoteColourCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Note_WeekDay_WeekDayId",
                        column: x => x.WeekDayId,
                        principalTable: "WeekDay",
                        principalColumn: "WeekDayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Note_NotesColourCategoryId",
                table: "Note",
                column: "NotesColourCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_WeekDayId",
                table: "Note",
                column: "WeekDayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Note");
        }
    }
}
