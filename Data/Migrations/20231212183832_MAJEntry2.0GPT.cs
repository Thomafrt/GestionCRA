using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionCRA.Data.Migrations
{
    /// <inheritdoc />
    public partial class MAJEntry20GPT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WeekNb",
                table: "Entries",
                newName: "NumeroSemaine");

            migrationBuilder.RenameColumn(
                name: "WednesdayHours",
                table: "Entries",
                newName: "HeuresVendredi");

            migrationBuilder.RenameColumn(
                name: "TuesdayHours",
                table: "Entries",
                newName: "HeuresSamedi");

            migrationBuilder.RenameColumn(
                name: "ThursdayHours",
                table: "Entries",
                newName: "HeuresMercredi");

            migrationBuilder.RenameColumn(
                name: "SundayHours",
                table: "Entries",
                newName: "HeuresMardi");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Entries",
                newName: "Etat");

            migrationBuilder.RenameColumn(
                name: "SaturdayHours",
                table: "Entries",
                newName: "HeuresLundi");

            migrationBuilder.RenameColumn(
                name: "MondayHours",
                table: "Entries",
                newName: "HeuresJeudi");

            migrationBuilder.RenameColumn(
                name: "FridayHours",
                table: "Entries",
                newName: "HeuresDimanche");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "Entries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreation",
                table: "Entries");

            migrationBuilder.RenameColumn(
                name: "NumeroSemaine",
                table: "Entries",
                newName: "WeekNb");

            migrationBuilder.RenameColumn(
                name: "HeuresVendredi",
                table: "Entries",
                newName: "WednesdayHours");

            migrationBuilder.RenameColumn(
                name: "HeuresSamedi",
                table: "Entries",
                newName: "TuesdayHours");

            migrationBuilder.RenameColumn(
                name: "HeuresMercredi",
                table: "Entries",
                newName: "ThursdayHours");

            migrationBuilder.RenameColumn(
                name: "HeuresMardi",
                table: "Entries",
                newName: "SundayHours");

            migrationBuilder.RenameColumn(
                name: "HeuresLundi",
                table: "Entries",
                newName: "SaturdayHours");

            migrationBuilder.RenameColumn(
                name: "HeuresJeudi",
                table: "Entries",
                newName: "MondayHours");

            migrationBuilder.RenameColumn(
                name: "HeuresDimanche",
                table: "Entries",
                newName: "FridayHours");

            migrationBuilder.RenameColumn(
                name: "Etat",
                table: "Entries",
                newName: "State");
        }
    }
}
