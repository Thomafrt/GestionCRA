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

        // Propriété de navigation pour la relation plusieurs à plusieurs avec Employee
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

        // Propriété pour stocker les identifiants des employés associés à la mission
        [NotMapped]
        public List<int> EmployeeIds { get; set; } = new List<int>();

        public virtual ICollection<Entry> Entries { get; set; } = new List<Entry>();

    }
}
