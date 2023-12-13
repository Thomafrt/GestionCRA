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

        public virtual ICollection<Mission> Missions { get; set; } = new List<Mission>();
        public virtual ICollection<Entry> Entries { get; set; } = new List<Entry>();

    }
}
