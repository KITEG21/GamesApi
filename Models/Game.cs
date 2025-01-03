using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace gamesApi.Models
{
    public class Game
    {
        public int Id { get; set; }
        
        [Required]
        [Range(0,30000000)]
        public long Copies { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The name can't be over the 50 characters")]
        [MinLength(3, ErrorMessage = "The name can't be less than 3 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50, ErrorMessage = "The name can't be over the 50 characters")]
        [MinLength(3, ErrorMessage = "The name can't be less than 3 characters")]
        public string Developers { get; set; } = string.Empty;
        public DateOnly Date { get; set;}    
    }
}