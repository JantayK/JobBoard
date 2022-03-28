using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeadHunter.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployerId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    KeySkills = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Experience = table.Column<int>(nullable: false),
                    Employment = table.Column<int>(nullable: true),
                    Salary = table.Column<decimal>(nullable: false),
                    Archived = table.Column<bool>(nullable: false),
                    PublishedAt = table.Column<DateTime>(nullable: false),
                    Contact = table.Column<string>(nullable: true),
                    HasTest = table.Column<bool>(nullable: false),
                    EmployerId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    SurName = table.Column<string>(maxLength: 50, nullable: false),
                    Login = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Experience = table.Column<int>(nullable: true),
                    Education = table.Column<int>(nullable: true),
                    EmployeeInfo = table.Column<string>(nullable: true),
                    VacancyId = table.Column<int>(nullable: true),
                    CompanyName = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FoundationYear = table.Column<int>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_VacancyId",
                table: "Users",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Vacancies_VacancyId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Vacancies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
