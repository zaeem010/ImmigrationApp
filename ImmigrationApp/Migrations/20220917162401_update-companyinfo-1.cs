using Microsoft.EntityFrameworkCore.Migrations;

namespace ImmigrationApp.Migrations
{
    public partial class updatecompanyinfo1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyInfo_JobMainCategory_JobMainCategoryId",
                table: "CompanyInfo");

            migrationBuilder.AlterColumn<long>(
                name: "JobMainCategoryId",
                table: "CompanyInfo",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyInfo_JobMainCategory_JobMainCategoryId",
                table: "CompanyInfo",
                column: "JobMainCategoryId",
                principalTable: "JobMainCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyInfo_JobMainCategory_JobMainCategoryId",
                table: "CompanyInfo");

            migrationBuilder.AlterColumn<long>(
                name: "JobMainCategoryId",
                table: "CompanyInfo",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyInfo_JobMainCategory_JobMainCategoryId",
                table: "CompanyInfo",
                column: "JobMainCategoryId",
                principalTable: "JobMainCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
