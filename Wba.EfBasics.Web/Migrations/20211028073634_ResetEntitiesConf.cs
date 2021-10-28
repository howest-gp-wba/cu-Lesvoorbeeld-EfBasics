using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wba.EfBasics.Web.Migrations
{
    public partial class ResetEntitiesConf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Coursestudents",
                schema: "dbo");

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

            migrationBuilder.RenameTable(
                name: "ContactInfos",
                schema: "dbo",
                newName: "ContactInfos");

            migrationBuilder.RenameColumn(
                name: "IdOfcontactInfo",
                table: "Teachers",
                newName: "ContactInfoId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Teachers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_IdOfcontactInfo",
                table: "Teachers",
                newName: "IX_Teachers_ContactInfoId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Students",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdOfTeacher",
                table: "Courses",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Courses",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_IdOfTeacher",
                table: "Courses",
                newName: "IX_Courses_TeacherId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "ContactInfos",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CoursesId = table.Column<long>(type: "bigint", nullable: false),
                    StudentsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.CoursesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentsId",
                table: "CourseStudent",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_ContactInfos_ContactInfoId",
                table: "Teachers",
                column: "ContactInfoId",
                principalTable: "ContactInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_ContactInfos_ContactInfoId",
                table: "Teachers");

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

            migrationBuilder.RenameTable(
                name: "ContactInfos",
                newName: "ContactInfos",
                newSchema: "dbo");

            migrationBuilder.RenameColumn(
                name: "ContactInfoId",
                schema: "dbo",
                table: "Teachers",
                newName: "IdOfcontactInfo");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "Teachers",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_ContactInfoId",
                schema: "dbo",
                table: "Teachers",
                newName: "IX_Teachers_IdOfcontactInfo");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "Students",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                schema: "dbo",
                table: "Courses",
                newName: "IdOfTeacher");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "Courses",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_TeacherId",
                schema: "dbo",
                table: "Courses",
                newName: "IX_Courses_IdOfTeacher");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "ContactInfos",
                newName: "ItemId");

            migrationBuilder.CreateTable(
                name: "Coursestudents",
                schema: "dbo",
                columns: table => new
                {
                    ItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOfCourse = table.Column<long>(type: "bigint", nullable: true),
                    IdOfStudent = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coursestudents", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Coursestudents_Courses_IdOfCourse",
                        column: x => x.IdOfCourse,
                        principalSchema: "dbo",
                        principalTable: "Courses",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Coursestudents_Students_IdOfStudent",
                        column: x => x.IdOfStudent,
                        principalSchema: "dbo",
                        principalTable: "Students",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coursestudents_IdOfCourse",
                schema: "dbo",
                table: "Coursestudents",
                column: "IdOfCourse");

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
    }
}
