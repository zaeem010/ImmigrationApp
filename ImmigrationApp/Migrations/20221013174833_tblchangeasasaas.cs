using Microsoft.EntityFrameworkCore.Migrations;

namespace ImmigrationApp.Migrations
{
    public partial class tblchangeasasaas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MutualAddress",
                table: "Job",
                type: "nvarchar(455)",
                maxLength: 455,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MutualAddress",
                table: "Job");
        }
    }
}
