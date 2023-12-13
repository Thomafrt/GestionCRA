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
        public virtual Mission? Mission { get; set; }

        [Required]
        public int EmployeeId { get; set; } = 1;
        public virtual Employee? Employee { get; set; }

        [Required]
        public EntryState State { get; set; } = EntryState.Sauvegarde;

        [Required]
        [Range(1,52)]
        public int Week { get; set; }

        [Range(0, 12, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? MondayHours { get; set; } = 0;
        [Range(0, 12, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? TuesdayHours { get; set; } = 0;
        [Range(0, 12, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? WednesdayHours { get; set; } = 0;
        [Range(0, 12, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? ThursdayHours { get; set; } = 0;
        [Range(0, 12, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? FridayHours { get; set; } = 0;
        [Range(0, 12, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? SaturdayHours { get; set; } = 0;
        [Range(0, 12, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? SundayHours { get; set; } = 0;

        [NotMapped]
        public int TotalHours
        {
            get
            {
                return (SundayHours ?? 0) + (MondayHours ?? 0) + (TuesdayHours ?? 0) + (WednesdayHours ?? 0)
                     + (ThursdayHours ?? 0) + (FridayHours ?? 0) + (SaturdayHours ?? 0);
            }
        }
    }

    public enum EntryState
    {
        Valide,
        Refuse,
        Sauvegarde,
        Soumis
    }
}
