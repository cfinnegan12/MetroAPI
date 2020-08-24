using System.ComponentModel.DataAnnotations;

namespace MetroAPI.Models
{
    public class Route
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(4)]
        public string RouteNumber { get; set; }

        [Required]
        public string Direction { get; set; }

        [Required]
        [MaxLength(68)]
        public string Description { get; set; }
    }
}
