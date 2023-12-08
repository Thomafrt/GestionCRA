﻿using System.ComponentModel.DataAnnotations;

namespace CRA.Models.Domain
{
    public class Admin
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
