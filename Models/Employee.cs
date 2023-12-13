using System.ComponentModel.DataAnnotations;

namespace CRA.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Propriété de navigation pour la relation plusieurs à plusieurs avec Mission
        public virtual ICollection<Mission> Missions { get; set; } = new List<Mission>();

        // Propriété de navigation pour la relation un à plusieurs avec Entry
        public virtual ICollection<Entry> Entries { get; set; } = new List<Entry>();

    }
}
