using Microsoft.EntityFrameworkCore.Migrations;

namespace ImmigrationApp.Migrations
{
    public partial class jobmodelupdatedaddcompanyid4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddForeignKey(
                name: "FK_Job_CompanyInfo_CompanyInfoId",
                table: "Job",
                column: "CompanyInfoId",
                principalTable: "CompanyInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_CompanyInfo_CompanyInfoId",
                table: "Job");

            
        }
    }
}
