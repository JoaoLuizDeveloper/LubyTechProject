using Microsoft.EntityFrameworkCore.Migrations;

namespace LubyTechAPI.Migrations
{
    public partial class longDeveloperCPFToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CPF",
                table: "Developers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
