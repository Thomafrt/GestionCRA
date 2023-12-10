using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionCRA.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifMission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeMission_Employees_EmployeesId",
                table: "EmployeeMission");

            migrationBuilder.RenameColumn(
                name: "EmployeesId",
                table: "EmployeeMission",
                newName: "AssignedId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeMission_Employees_AssignedId",
                table: "EmployeeMission",
                column: "AssignedId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeMission_Employees_AssignedId",
                table: "EmployeeMission");

            migrationBuilder.RenameColumn(
                name: "AssignedId",
                table: "EmployeeMission",
                newName: "EmployeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeMission_Employees_EmployeesId",
                table: "EmployeeMission",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
