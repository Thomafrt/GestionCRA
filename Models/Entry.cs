using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRA.Models
{
    public class Entry
    {
        public int Id { get; set; }

        [Required]
        public Mission Mission { get; set; }

        [Required]
        public int WeekNb { get; set; }
        public int? MondayHours { get; set; }
        public int? TuesdayHours { get; set; }
        public int? WednesdayHours { get; set; }
        public int? ThursdayHours { get; set; }
        public int? FridayHours { get; set; }
        public int? SaturdayHours { get; set; }
        public int? SundayHours { get; set; }

        [Required]
        // Clé étrangère pour Employee
        public int EmployeeId { get; set; }

        // Propriété de navigation pour Employee
        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee Employee { get; set; }
    }
}
