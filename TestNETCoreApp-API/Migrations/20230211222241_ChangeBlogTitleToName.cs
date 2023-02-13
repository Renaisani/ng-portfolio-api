using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestNETCoreAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBlogTitleToName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Blog",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Blog",
                newName: "Title");
        }
    }
}
