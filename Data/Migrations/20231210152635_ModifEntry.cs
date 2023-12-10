using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionCRA.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WeekNb",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeekNb",
                table: "Entries");
        }
    }
}
