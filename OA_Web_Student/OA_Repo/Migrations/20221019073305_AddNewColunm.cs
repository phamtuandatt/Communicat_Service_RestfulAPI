using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OA_Repo.Migrations
{
    public partial class AddNewColunm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaLop",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaLop",
                table: "Students");
        }
    }
}
