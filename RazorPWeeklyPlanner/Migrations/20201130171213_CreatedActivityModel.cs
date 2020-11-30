using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPWeeklyPlanner.Migrations
{
    public partial class CreatedActivityModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeekDayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activity_WeekDay_WeekDayId",
                        column: x => x.WeekDayId,
                        principalTable: "WeekDay",
                        principalColumn: "WeekDayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_WeekDayId",
                table: "Activity",
                column: "WeekDayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");
        }
    }
}
