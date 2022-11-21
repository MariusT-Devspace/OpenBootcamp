using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityApiBackend.Migrations
{
    public partial class FixSyllabusIdnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Syllabus_SyllabusId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "SyllabusId",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Syllabus_SyllabusId",
                table: "Courses",
                column: "SyllabusId",
                principalTable: "Syllabus",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Syllabus_SyllabusId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "SyllabusId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Syllabus_SyllabusId",
                table: "Courses",
                column: "SyllabusId",
                principalTable: "Syllabus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
