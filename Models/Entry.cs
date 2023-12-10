using System.ComponentModel.DataAnnotations;

namespace CRA.Models.Domain
{
    public class Entry
    {
        public int Id { get; set; }
        [Required]
        public Employee Employee { get; set; }
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
    }
}
