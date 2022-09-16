using Microsoft.EntityFrameworkCore.Migrations;

namespace ImmigrationApp.Migrations
{
    public partial class chatapp1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PeopleHub_UserId",
                table: "PeopleHub",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatAppHub_UserId",
                table: "ChatAppHub",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatAppHub_AspNetUsers_UserId",
                table: "ChatAppHub",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleHub_AspNetUsers_UserId",
                table: "PeopleHub",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatAppHub_AspNetUsers_UserId",
                table: "ChatAppHub");

            migrationBuilder.DropForeignKey(
                name: "FK_PeopleHub_AspNetUsers_UserId",
                table: "PeopleHub");

            migrationBuilder.DropIndex(
                name: "IX_PeopleHub_UserId",
                table: "PeopleHub");

            migrationBuilder.DropIndex(
                name: "IX_ChatAppHub_UserId",
                table: "ChatAppHub");
        }
    }
}
