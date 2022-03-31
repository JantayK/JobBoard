using Microsoft.EntityFrameworkCore.Migrations;

namespace HeadHunter.Migrations
{
    public partial class RemovedUnnecessaryField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Archived",
                table: "Vacancies");

            migrationBuilder.RenameColumn(
                name: "HasTest",
                table: "Vacancies",
                newName: "Hastest");

            migrationBuilder.AlterColumn<int>(
                name: "Hastest",
                table: "Vacancies",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hastest",
                table: "Vacancies",
                newName: "HasTest");

            migrationBuilder.AlterColumn<bool>(
                name: "HasTest",
                table: "Vacancies",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "Archived",
                table: "Vacancies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
