using Microsoft.EntityFrameworkCore.Migrations;

namespace ImmigrationApp.Migrations
{
    public partial class customresumeaddemailslug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CustomResume",
                type: "nvarchar(455)",
                maxLength: 455,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SlugName",
                table: "CustomResume",
                type: "nvarchar(455)",
                maxLength: 455,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "CustomResume");

            migrationBuilder.DropColumn(
                name: "SlugName",
                table: "CustomResume");
        }
    }
}
