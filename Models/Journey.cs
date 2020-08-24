using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MetroAPI.Models
{
    public class Journey
    {

        public int Id { get; set; }
        [Required]
        public Route Route { get; set; }
        [Required]
        public bool BankHolidays { get; set; }
        [Required]
        public bool Monday { get; set; }
        [Required]
        public bool Tuesday { get; set; }
        [Required]
        public bool Wednesday { get; set; }
        [Required]
        public bool Thursday { get; set; }
        [Required]
        public bool Friday { get; set; }
        [Required]
        public bool Saturday { get; set; }
        [Required]
        public bool Sunday { get; set; }
        [Required]
        public ICollection<Stop> Stops { get; set; }

    }
}
