﻿using System.ComponentModel.DataAnnotations;

namespace MetroAPI.Models
{
    public class Location
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(12)]
        public string ShortForm { get; set; }

        [MaxLength(48)]
        public string FullForm { get; set; }

        public int GridEasting { get; set; }
        public int GridNorthing { get; set; }
    }
}
