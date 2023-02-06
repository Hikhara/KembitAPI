using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    public class Koning
    {
        public int Id { get; set; }
        [Required]
        public int CastleId { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public int Year { get; set; }

    }
}
