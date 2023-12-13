using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRA.Models
{
    public class Entry
    {
        public int Id { get; set; }

        [Required]
        public int MissionId { get; set; } = 1;
        // Propriété de navigation pour la relation plusieurs à un avec Mission
        public virtual Mission? Mission { get; set; }

        [Required]
        public int EmployeeId { get; set; } = 1;
        // Propriété de navigation pour la relation plusieurs à un avec Employee
        public virtual Employee? Employee { get; set; }

        [Required]
        public EntryState State { get; set; } = EntryState.Sauvegarde;

        [Required]
        [Range(1,52)]
        public int Week { get; set; }


        public int? SundayHours { get; set; } = 0;
        public int? MondayHours { get; set; } = 0;
        public int? TuesdayHours { get; set; } = 0;
        public int? WednesdayHours { get; set; } = 0;
        public int? ThursdayHours { get; set; } = 0;
        public int? FridayHours { get; set; } = 0;
        public int? SaturdayHours { get; set; } = 0;
    }

    public enum EntryState
    {
        Valide,
        Refuse,
        Sauvegarde,
        Soumis
    }
}
