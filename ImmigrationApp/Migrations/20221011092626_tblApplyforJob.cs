using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImmigrationApp.Migrations
{
    public partial class tblApplyforJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplyforJob",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<long>(type: "bigint", nullable: false),
                    EmployerId = table.Column<long>(type: "bigint", nullable: false),
                    CanidateId = table.Column<long>(type: "bigint", nullable: false),
                    CoverLetter = table.Column<string>(type: "nvarchar(455)", maxLength: 455, nullable: true),
                    AppliedUsing = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: true),
                    AppliedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplyforJob", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplyforJob");
        }
    }
}
