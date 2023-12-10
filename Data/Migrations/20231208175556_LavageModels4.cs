using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionCRA.Data.Migrations
{
    /// <inheritdoc />
    public partial class LavageModels4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Missions_MissionId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_MissionId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MissionId",
                table: "Employees");

            migrationBuilder.CreateTable(
                name: "EmployeeMission",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    MissionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeMission", x => new { x.EmployeesId, x.MissionsId });
                    table.ForeignKey(
                        name: "FK_EmployeeMission_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeMission_Missions_MissionsId",
                        column: x => x.MissionsId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMission_MissionsId",
                table: "EmployeeMission",
                column: "MissionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeMission");

            migrationBuilder.AddColumn<int>(
                name: "MissionId",
                table: "Employees",
                type: "int",
                nullable: true);

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
        }
    }
}
