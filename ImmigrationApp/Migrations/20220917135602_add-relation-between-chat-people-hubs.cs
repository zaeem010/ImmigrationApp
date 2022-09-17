using Microsoft.EntityFrameworkCore.Migrations;

namespace ImmigrationApp.Migrations
{
    public partial class addrelationbetweenchatpeoplehubs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PeopleHubId",
                table: "ChatAppHub",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ChatAppHub_PeopleHubId",
                table: "ChatAppHub",
                column: "PeopleHubId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatAppHub_PeopleHub_PeopleHubId",
                table: "ChatAppHub",
                column: "PeopleHubId",
                principalTable: "PeopleHub",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatAppHub_PeopleHub_PeopleHubId",
                table: "ChatAppHub");

            migrationBuilder.DropIndex(
                name: "IX_ChatAppHub_PeopleHubId",
                table: "ChatAppHub");

            migrationBuilder.DropColumn(
                name: "PeopleHubId",
                table: "ChatAppHub");
        }
    }
}
