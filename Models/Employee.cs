using System.ComponentModel.DataAnnotations;

namespace CRA.Models.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public ICollection<Entry>? Entries { get; set; }
        public ICollection<Report>? Reports { get; set; }
    }
}
