using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionCRA.Data.Migrations
{
    /// <inheritdoc />
    public partial class FullGPT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MissionEmployeeAssignments_Employees_AssignedEmployeesId",
                table: "MissionEmployeeAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_MissionEmployeeAssignments_Missions_MissionsId",
                table: "MissionEmployeeAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Employees_EmployeeId",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MissionEmployeeAssignments",
                table: "MissionEmployeeAssignments");

            migrationBuilder.RenameTable(
                name: "MissionEmployeeAssignments",
                newName: "EmployeeMission");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Missions",
                newName: "Nom");

            migrationBuilder.RenameColumn(
                name: "EndWeek",
                table: "Missions",
                newName: "SemaineFin");

            migrationBuilder.RenameColumn(
                name: "BeginWeek",
                table: "Missions",
                newName: "SemaineDebut");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employees",
                newName: "Nom");

            migrationBuilder.RenameColumn(
                name: "AssignedEmployeesId",
                table: "EmployeeMission",
                newName: "EmployeesId");

            migrationBuilder.RenameIndex(
                name: "IX_MissionEmployeeAssignments_MissionsId",
                table: "EmployeeMission",
                newName: "IX_EmployeeMission_MissionsId");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MissionId",
                table: "Reports",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeMission",
                table: "EmployeeMission",
                columns: new[] { "EmployeesId", "MissionsId" });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_MissionId",
                table: "Reports",
                column: "MissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeMission_Employees_EmployeesId",
                table: "EmployeeMission",
                column: "EmployeesId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Employees_EmployeeId",
                table: "Reports",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Missions_MissionId",
                table: "Reports",
                column: "MissionId",
                principalTable: "Missions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeMission_Employees_EmployeesId",
                table: "EmployeeMission");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeMission_Missions_MissionsId",
                table: "EmployeeMission");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Employees_EmployeeId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Missions_MissionId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_MissionId",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeMission",
                table: "EmployeeMission");

            migrationBuilder.DropColumn(
                name: "MissionId",
                table: "Reports");

            migrationBuilder.RenameTable(
                name: "EmployeeMission",
                newName: "MissionEmployeeAssignments");

            migrationBuilder.RenameColumn(
                name: "SemaineFin",
                table: "Missions",
                newName: "EndWeek");

            migrationBuilder.RenameColumn(
                name: "SemaineDebut",
                table: "Missions",
                newName: "BeginWeek");

            migrationBuilder.RenameColumn(
                name: "Nom",
                table: "Missions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Nom",
                table: "Employees",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EmployeesId",
                table: "MissionEmployeeAssignments",
                newName: "AssignedEmployeesId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeMission_MissionsId",
                table: "MissionEmployeeAssignments",
                newName: "IX_MissionEmployeeAssignments_MissionsId");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Reports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MissionEmployeeAssignments",
                table: "MissionEmployeeAssignments",
                columns: new[] { "AssignedEmployeesId", "MissionsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MissionEmployeeAssignments_Employees_AssignedEmployeesId",
                table: "MissionEmployeeAssignments",
                column: "AssignedEmployeesId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Employees_EmployeeId",
                table: "Reports",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
