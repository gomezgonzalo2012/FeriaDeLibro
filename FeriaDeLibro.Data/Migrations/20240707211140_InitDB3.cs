using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeriaDeLibro.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitDB3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instituto",
                table: "Eventos");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Eventos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_CourseId",
                table: "Eventos",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Courses_CourseId",
                table: "Eventos",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Courses_CourseId",
                table: "Eventos");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_CourseId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Eventos");

            migrationBuilder.AddColumn<string>(
                name: "Instituto",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
