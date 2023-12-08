using System.ComponentModel.DataAnnotations;

namespace CRA.Models.Domain
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
    }
}
