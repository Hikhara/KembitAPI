using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Kasteel
    {
        [Required]
        public int Id { get; set; }
        

        public string? Name { get; set; }
    }
}
