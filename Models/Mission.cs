using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CRA.Models
{
    public class Mission
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int SemaineDebut { get; set; }

        [Required]
        public int SemaineFin { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
        [NotMapped]
        public List<int> EmployeeIds { get; set; } = new List<int>();

        public virtual ICollection<Entry> Entries { get; set; } = new List<Entry>();

    }
}
