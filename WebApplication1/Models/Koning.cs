﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Koning
    {

        [Required]
        public int Id { get; set; }

        public int CastleId { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }

        //[Range(1, 2100)]
        public int Year { get; set; }
    }
}
