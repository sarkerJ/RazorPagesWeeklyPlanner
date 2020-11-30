using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPWeeklyPlanner.Migrations
{
    public partial class CreatedNoteColourTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoteColourCategory",
                columns: table => new
                {
                    NoteColourCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteColourCategory", x => x.NoteColourCategoryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteColourCategory");
        }
    }
}
