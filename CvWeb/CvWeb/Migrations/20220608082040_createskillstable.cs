using Microsoft.EntityFrameworkCore.Migrations;

namespace CvWeb.Migrations
{
    public partial class createskillstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Skills");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
