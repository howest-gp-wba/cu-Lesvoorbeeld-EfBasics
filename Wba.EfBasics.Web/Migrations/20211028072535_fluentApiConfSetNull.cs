using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wba.EfBasics.Web.Migrations
{
    public partial class fluentApiConfSetNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coursestudents_Courses_IdOfCourse",
                schema: "dbo",
                table: "Coursestudents");

            migrationBuilder.DropForeignKey(
                name: "FK_Coursestudents_Students_IdOfStudent",
                schema: "dbo",
                table: "Coursestudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coursestudents",
                schema: "dbo",
                table: "Coursestudents");

            migrationBuilder.AlterColumn<long>(
                name: "IdOfStudent",
                schema: "dbo",
                table: "Coursestudents",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "IdOfCourse",
                schema: "dbo",
                table: "Coursestudents",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "ItemId",
                schema: "dbo",
                table: "Coursestudents",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                schema: "dbo",
                table: "Coursestudents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                schema: "dbo",
                table: "Coursestudents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coursestudents",
                schema: "dbo",
                table: "Coursestudents",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Coursestudents_IdOfCourse",
                schema: "dbo",
                table: "Coursestudents",
                column: "IdOfCourse");

            migrationBuilder.AddForeignKey(
                name: "FK_Coursestudents_Courses_IdOfCourse",
                schema: "dbo",
                table: "Coursestudents",
                column: "IdOfCourse",
                principalSchema: "dbo",
                principalTable: "Courses",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Coursestudents_Students_IdOfStudent",
                schema: "dbo",
                table: "Coursestudents",
                column: "IdOfStudent",
                principalSchema: "dbo",
                principalTable: "Students",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coursestudents_Courses_IdOfCourse",
                schema: "dbo",
                table: "Coursestudents");

            migrationBuilder.DropForeignKey(
                name: "FK_Coursestudents_Students_IdOfStudent",
                schema: "dbo",
                table: "Coursestudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coursestudents",
                schema: "dbo",
                table: "Coursestudents");

            migrationBuilder.DropIndex(
                name: "IX_Coursestudents_IdOfCourse",
                schema: "dbo",
                table: "Coursestudents");

            migrationBuilder.DropColumn(
                name: "ItemId",
                schema: "dbo",
                table: "Coursestudents");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                schema: "dbo",
                table: "Coursestudents");

            migrationBuilder.DropColumn(
                name: "DateModified",
                schema: "dbo",
                table: "Coursestudents");

            migrationBuilder.AlterColumn<long>(
                name: "IdOfStudent",
                schema: "dbo",
                table: "Coursestudents",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IdOfCourse",
                schema: "dbo",
                table: "Coursestudents",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coursestudents",
                schema: "dbo",
                table: "Coursestudents",
                columns: new[] { "IdOfCourse", "IdOfStudent" });

            migrationBuilder.AddForeignKey(
                name: "FK_Coursestudents_Courses_IdOfCourse",
                schema: "dbo",
                table: "Coursestudents",
                column: "IdOfCourse",
                principalSchema: "dbo",
                principalTable: "Courses",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coursestudents_Students_IdOfStudent",
                schema: "dbo",
                table: "Coursestudents",
                column: "IdOfStudent",
                principalSchema: "dbo",
                principalTable: "Students",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
