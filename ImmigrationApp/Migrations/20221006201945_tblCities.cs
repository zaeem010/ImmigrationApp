using Microsoft.EntityFrameworkCore.Migrations;

namespace ImmigrationApp.Migrations
{
    public partial class tblCities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityregion = table.Column<string>(type: "nvarchar(455)", maxLength: 455, nullable: true),
                    city = table.Column<string>(type: "nvarchar(455)", maxLength: 455, nullable: true),
                    region = table.Column<string>(type: "nvarchar(455)", maxLength: 455, nullable: true),
                    countrycode = table.Column<string>(type: "nvarchar(455)", maxLength: 455, nullable: true),
                    latitude = table.Column<double>(type: "float", nullable: false),
                    longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
