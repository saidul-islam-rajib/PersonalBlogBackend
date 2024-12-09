using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sober.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Changecolumnname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommentorName",
                table: "Comments",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CommentorComment",
                table: "Comments",
                newName: "Comments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Comments",
                newName: "CommentorName");

            migrationBuilder.RenameColumn(
                name: "Comments",
                table: "Comments",
                newName: "CommentorComment");
        }
    }
}
