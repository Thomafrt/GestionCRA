using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRA.Models
{
    public class Report
    {
        public int Id { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
        [Required]
        public int WeekStart { get; set; }
        [Required]
        public int WeekEnd { get; set; }
        public List<Entry> Entries { get; set; } = new List<Entry>();

    }
}
