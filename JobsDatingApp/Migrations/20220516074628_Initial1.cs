﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobsDatingApp.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Vacancies_LastViewedVacancyId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "LastViewedVacancyId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Vacancies_LastViewedVacancyId",
                table: "Users",
                column: "LastViewedVacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Vacancies_LastViewedVacancyId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "LastViewedVacancyId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Vacancies_LastViewedVacancyId",
                table: "Users",
                column: "LastViewedVacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
