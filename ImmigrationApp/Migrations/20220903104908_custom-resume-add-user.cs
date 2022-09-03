using Microsoft.EntityFrameworkCore.Migrations;

namespace ImmigrationApp.Migrations
{
    public partial class customresumeadduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Relocate",
                table: "CustomResume",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowtoPublic",
                table: "CustomResume",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CustomResume",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomResume_UserId",
                table: "CustomResume",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomResume_AspNetUsers_UserId",
                table: "CustomResume",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomResume_AspNetUsers_UserId",
                table: "CustomResume");

            migrationBuilder.DropIndex(
                name: "IX_CustomResume_UserId",
                table: "CustomResume");

            migrationBuilder.DropColumn(
                name: "Relocate",
                table: "CustomResume");

            migrationBuilder.DropColumn(
                name: "ShowtoPublic",
                table: "CustomResume");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CustomResume");
        }
    }
}
