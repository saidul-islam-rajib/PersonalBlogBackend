using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sober.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddnewmigrationforEducations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExperienceSkills_Experiences_ExperienceId",
                table: "ExperienceSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExperienceSkills",
                table: "ExperienceSkills");

            migrationBuilder.AlterColumn<Guid>(
                name: "ExperienceId",
                table: "ExperienceSkills",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "EducationId",
                table: "ExperienceSkills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExperienceSkills",
                table: "ExperienceSkills",
                columns: new[] { "EducationId", "SkillId" });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstituteName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InstituteLogo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Department = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceSkills_ExperienceId",
                table: "ExperienceSkills",
                column: "ExperienceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceSkills_Educations_EducationId",
                table: "ExperienceSkills",
                column: "EducationId",
                principalTable: "Educations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceSkills_Experiences_ExperienceId",
                table: "ExperienceSkills",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExperienceSkills_Educations_EducationId",
                table: "ExperienceSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperienceSkills_Experiences_ExperienceId",
                table: "ExperienceSkills");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExperienceSkills",
                table: "ExperienceSkills");

            migrationBuilder.DropIndex(
                name: "IX_ExperienceSkills_ExperienceId",
                table: "ExperienceSkills");

            migrationBuilder.DropColumn(
                name: "EducationId",
                table: "ExperienceSkills");

            migrationBuilder.AlterColumn<Guid>(
                name: "ExperienceId",
                table: "ExperienceSkills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExperienceSkills",
                table: "ExperienceSkills",
                columns: new[] { "ExperienceId", "SkillId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceSkills_Experiences_ExperienceId",
                table: "ExperienceSkills",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
