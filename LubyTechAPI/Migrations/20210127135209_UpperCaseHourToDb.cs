using Microsoft.EntityFrameworkCore.Migrations;

namespace LubyTechAPI.Migrations
{
    public partial class UpperCaseHourToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dateEnd",
                table: "Hours",
                newName: "DateEnd");

            migrationBuilder.RenameColumn(
                name: "dateBegin",
                table: "Hours",
                newName: "DateBegin");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "Hours",
                newName: "Created");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateEnd",
                table: "Hours",
                newName: "dateEnd");

            migrationBuilder.RenameColumn(
                name: "DateBegin",
                table: "Hours",
                newName: "dateBegin");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Hours",
                newName: "created");
        }
    }
}
