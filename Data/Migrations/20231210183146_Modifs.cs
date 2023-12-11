using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionCRA.Data.Migrations
{
    /// <inheritdoc />
    public partial class Modifs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeMission_Employees_AssignedId",
                table: "EmployeeMission");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeMission_Missions_MissionsId",
                table: "EmployeeMission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeMission",
                table: "EmployeeMission");

            migrationBuilder.RenameTable(
                name: "EmployeeMission",
                newName: "MissionEmployeeAssignments");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeMission_MissionsId",
                table: "MissionEmployeeAssignments",
                newName: "IX_MissionEmployeeAssignments_MissionsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MissionEmployeeAssignments",
                table: "MissionEmployeeAssignments",
                columns: new[] { "AssignedId", "MissionsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MissionEmployeeAssignments_Employees_AssignedId",
                table: "MissionEmployeeAssignments",
                column: "AssignedId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MissionEmployeeAssignments_Missions_MissionsId",
                table: "MissionEmployeeAssignments",
                column: "MissionsId",
                principalTable: "Missions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MissionEmployeeAssignments_Employees_AssignedId",
                table: "MissionEmployeeAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_MissionEmployeeAssignments_Missions_MissionsId",
                table: "MissionEmployeeAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MissionEmployeeAssignments",
                table: "MissionEmployeeAssignments");

            migrationBuilder.RenameTable(
                name: "MissionEmployeeAssignments",
                newName: "EmployeeMission");

            migrationBuilder.RenameIndex(
                name: "IX_MissionEmployeeAssignments_MissionsId",
                table: "EmployeeMission",
                newName: "IX_EmployeeMission_MissionsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeMission",
                table: "EmployeeMission",
                columns: new[] { "AssignedId", "MissionsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeMission_Employees_AssignedId",
                table: "EmployeeMission",
                column: "AssignedId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeMission_Missions_MissionsId",
                table: "EmployeeMission",
                column: "MissionsId",
                principalTable: "Missions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
