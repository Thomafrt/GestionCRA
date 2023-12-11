using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRA.Models
{
    public class Report
    {
        public int Id { get; set; }
        [Required]
        public int BeginWeek { get; set; }
        [Required]
        public int EndWeek { get; set; }
        [Required]
        public ICollection<Entry>? Entries { get; set; }

        // Clé étrangère pour Employee
        public int EmployeeId { get; set; }

        // Propriété de navigation pour Employee
        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee Employee { get; set; }
    }
}
