using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MetroAPI.Models
{
    public class Stop
    {
        public int Id { get; set; }

        [Required]
        public Location Location{ get; set; }

        [Column(TypeName ="time(0)")]
        public TimeSpan Time { get; set; }
        
        //O = Origin, I = Intermediate, D = Destination
        public char StopType { get; set; }
    }
}
