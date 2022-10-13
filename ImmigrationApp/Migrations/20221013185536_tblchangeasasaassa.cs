using Microsoft.EntityFrameworkCore.Migrations;

namespace ImmigrationApp.Migrations
{
    public partial class tblchangeasasaassa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CallBy",
                table: "PeopleHub",
                type: "nvarchar(455)",
                maxLength: 455,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CallBy",
                table: "PeopleHub");
        }
    }
}
