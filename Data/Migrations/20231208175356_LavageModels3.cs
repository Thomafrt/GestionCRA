using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionCRA.Data.Migrations
{
    /// <inheritdoc />
    public partial class LavageModels3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Mission_MissionId",
                table: "Entries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mission",
                table: "Mission");

            migrationBuilder.RenameTable(
                name: "Mission",
                newName: "Missions");

            migrationBuilder.AddColumn<int>(
                name: "MissionId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Missions",
                table: "Missions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_MissionId",
                table: "Employees",
                column: "MissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Missions_MissionId",
                table: "Employees",
                column: "MissionId",
                principalTable: "Missions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Missions_MissionId",
                table: "Entries",
                column: "MissionId",
                principalTable: "Missions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Missions_MissionId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Missions_MissionId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Employees_MissionId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Missions",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "MissionId",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Missions",
                newName: "Mission");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mission",
                table: "Mission",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Mission_MissionId",
                table: "Entries",
                column: "MissionId",
                principalTable: "Mission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
