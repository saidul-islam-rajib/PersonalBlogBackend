using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sober.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Modifiedmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Educations",
                newName: "EducationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EducationId",
                table: "Educations",
                newName: "Id");
        }
    }
}
