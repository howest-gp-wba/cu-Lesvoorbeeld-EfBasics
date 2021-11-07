using Microsoft.EntityFrameworkCore.Migrations;

namespace Wba.EfBasics.Web.Migrations
{
    public partial class ChangeContactInfoToNullAllowed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_ContactInfos_ContactInfoId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_ContactInfoId",
                table: "Teachers");

            migrationBuilder.AlterColumn<long>(
                name: "ContactInfoId",
                table: "Teachers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_ContactInfoId",
                table: "Teachers",
                column: "ContactInfoId",
                unique: true,
                filter: "[ContactInfoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_ContactInfos_ContactInfoId",
                table: "Teachers",
                column: "ContactInfoId",
                principalTable: "ContactInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_ContactInfos_ContactInfoId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_ContactInfoId",
                table: "Teachers");

            migrationBuilder.AlterColumn<long>(
                name: "ContactInfoId",
                table: "Teachers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_ContactInfoId",
                table: "Teachers",
                column: "ContactInfoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_ContactInfos_ContactInfoId",
                table: "Teachers",
                column: "ContactInfoId",
                principalTable: "ContactInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
