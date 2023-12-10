using System.ComponentModel.DataAnnotations;

namespace CRA.Models.Domain
{
    public class Mission
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int BeginWeek { get; set; }
        [Required]
        public int EndWeek { get; set; }
        [Required]
        public ICollection<Employee>? Assigned { get; set; }
    }
}