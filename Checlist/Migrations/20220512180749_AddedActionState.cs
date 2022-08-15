using Microsoft.EntityFrameworkCore.Migrations;

namespace Checlist.Migrations
{
    public partial class AddedActionState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Done",
                table: "Actions");

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Actions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Actions");

            migrationBuilder.AddColumn<bool>(
                name: "Done",
                table: "Actions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
