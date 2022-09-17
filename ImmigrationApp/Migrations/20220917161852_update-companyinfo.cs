using Microsoft.EntityFrameworkCore.Migrations;

namespace ImmigrationApp.Migrations
{
    public partial class updatecompanyinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Industry",
                table: "CompanyInfo");

            migrationBuilder.AddColumn<long>(
                name: "JobMainCategoryId",
                table: "CompanyInfo",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyInfo_JobMainCategoryId",
                table: "CompanyInfo",
                column: "JobMainCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyInfo_JobMainCategory_JobMainCategoryId",
                table: "CompanyInfo",
                column: "JobMainCategoryId",
                principalTable: "JobMainCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyInfo_JobMainCategory_JobMainCategoryId",
                table: "CompanyInfo");

            migrationBuilder.DropIndex(
                name: "IX_CompanyInfo_JobMainCategoryId",
                table: "CompanyInfo");

            migrationBuilder.DropColumn(
                name: "JobMainCategoryId",
                table: "CompanyInfo");

            migrationBuilder.AddColumn<string>(
                name: "Industry",
                table: "CompanyInfo",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
