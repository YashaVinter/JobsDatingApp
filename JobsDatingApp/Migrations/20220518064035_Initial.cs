using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobsDatingApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    ShortDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacancies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LastViewedVacancy",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VacancyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastViewedVacancy", x => new { x.UserId, x.VacancyId });
                    table.ForeignKey(
                        name: "FK_LastViewedVacancy_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LastViewedVacancy_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserVacancy",
                columns: table => new
                {
                    LikedUsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LikedVacanciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVacancy", x => new { x.LikedUsersId, x.LikedVacanciesId });
                    table.ForeignKey(
                        name: "FK_UserVacancy_Users_LikedUsersId",
                        column: x => x.LikedUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserVacancy_Vacancies_LikedVacanciesId",
                        column: x => x.LikedVacanciesId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "FullDesc", "Name", "PhotoPath", "ShortDesc" },
                values: new object[] { 1, "State company Sber", "Sber", "/Files/CompanyPhoto/Sber.jpg", "Sber company" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "FullDesc", "Name", "PhotoPath", "ShortDesc" },
                values: new object[] { 2, "Private company VTB", "VTB", "/Files/CompanyPhoto/Vtb.jpg", "VTB company" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Login", "Name", "Password" },
                values: new object[] { new Guid("a4e00079-9248-4785-a40d-67720856e2f0"), "test@mail.com", "Bob123", "Bob", "123456" });

            migrationBuilder.InsertData(
                table: "Vacancies",
                columns: new[] { "Id", "CompanyId", "FullDesc", "Name", "Salary", "ShortDesc" },
                values: new object[,]
                {
                    { 1, 1, "Junior position in Sber", "Junior", 50000.0, "Junior position" },
                    { 2, 1, "Middle position in Sber", "Middle", 100000.0, "Middle position" },
                    { 3, 2, "Junior position in Vtb", "Junior", 45000.0, "Junior position" },
                    { 4, 2, "Middle position in Vtb", "Middle", 110000.0, "Middle position" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LastViewedVacancy_UserId",
                table: "LastViewedVacancy",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LastViewedVacancy_VacancyId",
                table: "LastViewedVacancy",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVacancy_LikedVacanciesId",
                table: "UserVacancy",
                column: "LikedVacanciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_CompanyId",
                table: "Vacancies",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LastViewedVacancy");

            migrationBuilder.DropTable(
                name: "UserVacancy");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vacancies");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
