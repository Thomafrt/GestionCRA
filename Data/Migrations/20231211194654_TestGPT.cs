using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionCRA.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestGPT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MissionEmployeeAssignments_Employees_AssignedId",
                table: "MissionEmployeeAssignments");

            migrationBuilder.RenameColumn(
                name: "AssignedId",
                table: "MissionEmployeeAssignments",
                newName: "AssignedEmployeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_MissionEmployeeAssignments_Employees_AssignedEmployeesId",
                table: "MissionEmployeeAssignments",
                column: "AssignedEmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MissionEmployeeAssignments_Employees_AssignedEmployeesId",
                table: "MissionEmployeeAssignments");

            migrationBuilder.RenameColumn(
                name: "AssignedEmployeesId",
                table: "MissionEmployeeAssignments",
                newName: "AssignedId");

            migrationBuilder.AddForeignKey(
                name: "FK_MissionEmployeeAssignments_Employees_AssignedId",
                table: "MissionEmployeeAssignments",
                column: "AssignedId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
