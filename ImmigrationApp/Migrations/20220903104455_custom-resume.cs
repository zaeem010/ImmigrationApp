using Microsoft.EntityFrameworkCore.Migrations;

namespace ImmigrationApp.Migrations
{
    public partial class customresume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomResume",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(455)", maxLength: 455, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(455)", maxLength: 455, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(455)", maxLength: 455, nullable: true),
                    ShowPhoneNumber = table.Column<bool>(type: "bit", nullable: false),
                    Headline = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(455)", maxLength: 455, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Province = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomResume", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(455)", maxLength: 455, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResumeEducation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomResumeId = table.Column<long>(type: "bigint", nullable: false),
                    LevelofEducation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FieldofStudy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SchoolName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StudyCountry = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StudyCity = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CurrentlyEnrolled = table.Column<bool>(type: "bit", nullable: false),
                    FromYear = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FromMonth = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ToYear = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ToMonth = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeEducation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeEducation_CustomResume_CustomResumeId",
                        column: x => x.CustomResumeId,
                        principalTable: "CustomResume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeExperience",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomResumeId = table.Column<long>(type: "bigint", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Company = table.Column<string>(type: "nvarchar(455)", maxLength: 455, nullable: true),
                    JobCountry = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    JobCity = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CurrentlyEnrolled = table.Column<bool>(type: "bit", nullable: false),
                    FromYear = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FromMonth = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ToYear = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ToMonth = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeExperience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeExperience_CustomResume_CustomResumeId",
                        column: x => x.CustomResumeId,
                        principalTable: "CustomResume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeLanguageChild",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomResumeId = table.Column<long>(type: "bigint", nullable: false),
                    Values = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeLanguageChild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeLanguageChild_CustomResume_CustomResumeId",
                        column: x => x.CustomResumeId,
                        principalTable: "CustomResume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeLinkChild",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomResumeId = table.Column<long>(type: "bigint", nullable: false),
                    Values = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeLinkChild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeLinkChild_CustomResume_CustomResumeId",
                        column: x => x.CustomResumeId,
                        principalTable: "CustomResume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeSkillChild",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomResumeId = table.Column<long>(type: "bigint", nullable: false),
                    SkillId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeSkillChild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeSkillChild_CustomResume_CustomResumeId",
                        column: x => x.CustomResumeId,
                        principalTable: "CustomResume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeSkillChild_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResumeEducation_CustomResumeId",
                table: "ResumeEducation",
                column: "CustomResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeExperience_CustomResumeId",
                table: "ResumeExperience",
                column: "CustomResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeLanguageChild_CustomResumeId",
                table: "ResumeLanguageChild",
                column: "CustomResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeLinkChild_CustomResumeId",
                table: "ResumeLinkChild",
                column: "CustomResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeSkillChild_CustomResumeId",
                table: "ResumeSkillChild",
                column: "CustomResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeSkillChild_SkillId",
                table: "ResumeSkillChild",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResumeEducation");

            migrationBuilder.DropTable(
                name: "ResumeExperience");

            migrationBuilder.DropTable(
                name: "ResumeLanguageChild");

            migrationBuilder.DropTable(
                name: "ResumeLinkChild");

            migrationBuilder.DropTable(
                name: "ResumeSkillChild");

            migrationBuilder.DropTable(
                name: "CustomResume");

            migrationBuilder.DropTable(
                name: "Skill");
        }
    }
}
