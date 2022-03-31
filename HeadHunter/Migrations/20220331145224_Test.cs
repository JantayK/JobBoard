using Microsoft.EntityFrameworkCore.Migrations;

namespace HeadHunter.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Users_EmployerId1",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_EmployerId1",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "EmployerId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "EmployerId1",
                table: "Vacancies");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Vacancies",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KeySkills",
                table: "Vacancies",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Vacancies",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Contact",
                table: "Vacancies",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Vacancies",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpId",
                table: "Vacancies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_EmpId",
                table: "Vacancies",
                column: "EmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Users_EmpId",
                table: "Vacancies",
                column: "EmpId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Users_EmpId",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_EmpId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "Vacancies");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "KeySkills",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 70);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 70);

            migrationBuilder.AlterColumn<string>(
                name: "Contact",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<long>(
                name: "EmployerId",
                table: "Vacancies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "EmployerId1",
                table: "Vacancies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_EmployerId1",
                table: "Vacancies",
                column: "EmployerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Users_EmployerId1",
                table: "Vacancies",
                column: "EmployerId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
