using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        public ICollection<Employee>? Assigned { get; set; }
        [NotMapped]
        public List<Employee> AllEmployees { get; set; }
        [NotMapped]
        public List<int> AssignedEmployeeIds { get; set; }
    }
}