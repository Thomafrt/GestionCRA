using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionCRA.Data.Migrations
{
    /// <inheritdoc />
    public partial class LavageModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignmentEmployee");

            migrationBuilder.DropTable(
                name: "WorkDays");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "EntryLines");

            migrationBuilder.AddColumn<int>(
                name: "BeginWeek",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EndWeek",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BeginWeek",
                table: "Mission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EndWeek",
                table: "Mission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FridayHours",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MissionId",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MondayHours",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SaturdayHours",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SundayHours",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThursdayHours",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TuesdayHours",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WednesdayHours",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entries_MissionId",
                table: "Entries",
                column: "MissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Mission_MissionId",
                table: "Entries",
                column: "MissionId",
                principalTable: "Mission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Mission_MissionId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_MissionId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "BeginWeek",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "EndWeek",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "BeginWeek",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "EndWeek",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "FridayHours",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "MissionId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "MondayHours",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "SaturdayHours",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "SundayHours",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "ThursdayHours",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "TuesdayHours",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "WednesdayHours",
                table: "Entries");

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MissionsId = table.Column<int>(type: "int", nullable: false),
                    BeginWeekNb = table.Column<int>(type: "int", nullable: false),
                    EndWeekNb = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Mission_MissionsId",
                        column: x => x.MissionsId,
                        principalTable: "Mission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntryLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryId = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryLines_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AssignmentEmployee",
                columns: table => new
                {
                    AssignmentsId = table.Column<int>(type: "int", nullable: false),
                    EmployeesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentEmployee", x => new { x.AssignmentsId, x.EmployeesId });
                    table.ForeignKey(
                        name: "FK_AssignmentEmployee_Assignments_AssignmentsId",
                        column: x => x.AssignmentsId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignmentEmployee_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryLineId = table.Column<int>(type: "int", nullable: true),
                    EveningWork = table.Column<bool>(type: "bit", nullable: false),
                    MorningWork = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkDays_EntryLines_EntryLineId",
                        column: x => x.EntryLineId,
                        principalTable: "EntryLines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentEmployee_EmployeesId",
                table: "AssignmentEmployee",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_MissionsId",
                table: "Assignments",
                column: "MissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryLines_EntryId",
                table: "EntryLines",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkDays_EntryLineId",
                table: "WorkDays",
                column: "EntryLineId");
        }
    }
}
