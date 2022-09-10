using Microsoft.EntityFrameworkCore.Migrations;

namespace ImmigrationApp.Migrations
{
    public partial class tblupdateskillchild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResumeSkillChild_Skill_SkillId",
                table: "ResumeSkillChild");

            migrationBuilder.DropIndex(
                name: "IX_ResumeSkillChild_SkillId",
                table: "ResumeSkillChild");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "ResumeSkillChild");

            migrationBuilder.AddColumn<string>(
                name: "NormalizedSkillName",
                table: "ResumeSkillChild",
                type: "nvarchar(455)",
                maxLength: 455,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SkillName",
                table: "ResumeSkillChild",
                type: "nvarchar(455)",
                maxLength: 455,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalizedSkillName",
                table: "ResumeSkillChild");

            migrationBuilder.DropColumn(
                name: "SkillName",
                table: "ResumeSkillChild");

            migrationBuilder.AddColumn<long>(
                name: "SkillId",
                table: "ResumeSkillChild",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ResumeSkillChild_SkillId",
                table: "ResumeSkillChild",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResumeSkillChild_Skill_SkillId",
                table: "ResumeSkillChild",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
