using Microsoft.EntityFrameworkCore.Migrations;

namespace ImmigrationApp.Migrations
{
    public partial class tblupdateskillchilda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalizedSkillName",
                table: "ResumeSkillChild");

            migrationBuilder.AddColumn<string>(
                name: "NormalizedName",
                table: "Skill",
                type: "nvarchar(455)",
                maxLength: 455,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SkillName",
                table: "ResumeSkillChild",
                type: "nvarchar(455)",
                maxLength: 455,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(455)",
                oldMaxLength: 455);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalizedName",
                table: "Skill");

            migrationBuilder.AlterColumn<string>(
                name: "SkillName",
                table: "ResumeSkillChild",
                type: "nvarchar(455)",
                maxLength: 455,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(455)",
                oldMaxLength: 455,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedSkillName",
                table: "ResumeSkillChild",
                type: "nvarchar(455)",
                maxLength: 455,
                nullable: true);
        }
    }
}
