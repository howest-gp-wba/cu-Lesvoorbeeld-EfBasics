using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wba.EfBasics.Web.Migrations
{
    public partial class fluentApiConf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "Teachers",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Students",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Courses",
                newSchema: "dbo");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                schema: "dbo",
                table: "Courses",
                newName: "IdOfTeacher");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_TeacherId",
                schema: "dbo",
                table: "Courses",
                newName: "IX_Courses_IdOfTeacher");

            migrationBuilder.AlterColumn<decimal>(
                name: "YearlyWage",
                schema: "dbo",
                table: "Teachers",
                type: "money",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<long>(
                name: "IdOfcontactInfo",
                schema: "dbo",
                table: "Teachers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Courses",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ContactInfos",
                schema: "dbo",
                columns: table => new
                {
                    ItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "Coursestudents",
                schema: "dbo",
                columns: table => new
                {
                    IdOfCourse = table.Column<long>(type: "bigint", nullable: false),
                    IdOfStudent = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coursestudents", x => new { x.IdOfCourse, x.IdOfStudent });
                    table.ForeignKey(
                        name: "FK_Coursestudents_Courses_IdOfCourse",
                        column: x => x.IdOfCourse,
                        principalSchema: "dbo",
                        principalTable: "Courses",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Coursestudents_Students_IdOfStudent",
                        column: x => x.IdOfStudent,
                        principalSchema: "dbo",
                        principalTable: "Students",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_IdOfcontactInfo",
                schema: "dbo",
                table: "Teachers",
                column: "IdOfcontactInfo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coursestudents_IdOfStudent",
                schema: "dbo",
                table: "Coursestudents",
                column: "IdOfStudent");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_IdOfTeacher",
                schema: "dbo",
                table: "Courses",
                column: "IdOfTeacher",
                principalSchema: "dbo",
                principalTable: "Teachers",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_ContactInfos_IdOfcontactInfo",
                schema: "dbo",
                table: "Teachers",
                column: "IdOfcontactInfo",
                principalSchema: "dbo",
                principalTable: "ContactInfos",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_IdOfTeacher",
                schema: "dbo",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_ContactInfos_IdOfcontactInfo",
                schema: "dbo",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "ContactInfos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Coursestudents",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_IdOfcontactInfo",
                schema: "dbo",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "IdOfcontactInfo",
                schema: "dbo",
                table: "Teachers");

            migrationBuilder.RenameTable(
                name: "Teachers",
                schema: "dbo",
                newName: "Teachers");

            migrationBuilder.RenameTable(
                name: "Students",
                schema: "dbo",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Courses",
                schema: "dbo",
                newName: "Courses");

            migrationBuilder.RenameColumn(
                name: "IdOfTeacher",
                table: "Courses",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_IdOfTeacher",
                table: "Courses",
                newName: "IX_Courses_TeacherId");

            migrationBuilder.AlterColumn<decimal>(
                name: "YearlyWage",
                table: "Teachers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldPrecision: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CoursesItemId = table.Column<long>(type: "bigint", nullable: false),
                    StudentsItemId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.CoursesItemId, x.StudentsItemId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Courses_CoursesItemId",
                        column: x => x.CoursesItemId,
                        principalTable: "Courses",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Students_StudentsItemId",
                        column: x => x.StudentsItemId,
                        principalTable: "Students",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentsItemId",
                table: "CourseStudent",
                column: "StudentsItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
