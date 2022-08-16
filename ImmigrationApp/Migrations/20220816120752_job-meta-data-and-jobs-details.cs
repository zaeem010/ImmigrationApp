using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImmigrationApp.Migrations
{
    public partial class jobmetadataandjobsdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BenefitOffered",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(455)", maxLength: 455, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitOffered", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobMainCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(555)", maxLength: 555, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobMainCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobSchedule",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(455)", maxLength: 455, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSchedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(455)", maxLength: 455, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupplementalPay",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(455)", maxLength: 455, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplementalPay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobSubCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(555)", maxLength: 555, nullable: false),
                    JobMainCategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSubCategory_JobMainCategory_JobMainCategoryId",
                        column: x => x.JobMainCategoryId,
                        principalTable: "JobMainCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(555)", maxLength: 555, nullable: false),
                    SpecificAddress = table.Column<bool>(type: "bit", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Province = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    PlanedstartDate = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Numberofvaccant = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HireSpeed = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ShowPayby = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MinPay = table.Column<double>(type: "float", nullable: false),
                    MaxPay = table.Column<double>(type: "float", nullable: false),
                    Rate = table.Column<string>(type: "nvarchar(155)", maxLength: 155, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumeSubmit = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Deadline = table.Column<bool>(type: "bit", nullable: false),
                    DeadlineDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobSubCategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Job_JobSubCategory_JobSubCategoryId",
                        column: x => x.JobSubCategoryId,
                        principalTable: "JobSubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BenefitOfferedChild",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<long>(type: "bigint", nullable: false),
                    BenefitOfferedId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitOfferedChild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BenefitOfferedChild_BenefitOffered_BenefitOfferedId",
                        column: x => x.BenefitOfferedId,
                        principalTable: "BenefitOffered",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BenefitOfferedChild_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobEmailChild",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<long>(type: "bigint", nullable: false),
                    Emails = table.Column<string>(type: "nvarchar(455)", maxLength: 455, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobEmailChild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobEmailChild_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobScheduleChild",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<long>(type: "bigint", nullable: false),
                    JobScheduleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobScheduleChild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobScheduleChild_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobScheduleChild_JobSchedule_JobScheduleId",
                        column: x => x.JobScheduleId,
                        principalTable: "JobSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobTypeChild",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<long>(type: "bigint", nullable: false),
                    Hours = table.Column<double>(type: "float", nullable: true),
                    ContractLength = table.Column<double>(type: "float", nullable: true),
                    ContractPeriod = table.Column<string>(type: "nvarchar(155)", maxLength: 155, nullable: true),
                    JobTypeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypeChild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobTypeChild_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobTypeChild_JobType_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplementalPayChild",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<long>(type: "bigint", nullable: false),
                    SupplementalPayId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplementalPayChild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplementalPayChild_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplementalPayChild_SupplementalPay_SupplementalPayId",
                        column: x => x.SupplementalPayId,
                        principalTable: "SupplementalPay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BenefitOfferedChild_BenefitOfferedId",
                table: "BenefitOfferedChild",
                column: "BenefitOfferedId");

            migrationBuilder.CreateIndex(
                name: "IX_BenefitOfferedChild_JobId",
                table: "BenefitOfferedChild",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_JobSubCategoryId",
                table: "Job",
                column: "JobSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobEmailChild_JobId",
                table: "JobEmailChild",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobScheduleChild_JobId",
                table: "JobScheduleChild",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobScheduleChild_JobScheduleId",
                table: "JobScheduleChild",
                column: "JobScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSubCategory_JobMainCategoryId",
                table: "JobSubCategory",
                column: "JobMainCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTypeChild_JobId",
                table: "JobTypeChild",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTypeChild_JobTypeId",
                table: "JobTypeChild",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplementalPayChild_JobId",
                table: "SupplementalPayChild",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplementalPayChild_SupplementalPayId",
                table: "SupplementalPayChild",
                column: "SupplementalPayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BenefitOfferedChild");

            migrationBuilder.DropTable(
                name: "JobEmailChild");

            migrationBuilder.DropTable(
                name: "JobScheduleChild");

            migrationBuilder.DropTable(
                name: "JobTypeChild");

            migrationBuilder.DropTable(
                name: "SupplementalPayChild");

            migrationBuilder.DropTable(
                name: "BenefitOffered");

            migrationBuilder.DropTable(
                name: "JobSchedule");

            migrationBuilder.DropTable(
                name: "JobType");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "SupplementalPay");

            migrationBuilder.DropTable(
                name: "JobSubCategory");

            migrationBuilder.DropTable(
                name: "JobMainCategory");
        }
    }
}
