using MetroAPI.Models;

namespace MetroAPI.DTOs
{
    public class OperationDays{
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
    }
    public class JourneyReadDTO
    {

        public int Id { get; set; }
        public bool BankHolidays { get; set; }
        public Route Route { get; set; }
        public OperationDays OperationDays { get; set; }

        public JourneyReadDTO(Journey journey)
        {
            this.Id = journey.Id;
            this.Route = journey.Route;
            this.BankHolidays = journey.BankHolidays;
            this.OperationDays = new OperationDays {
                Monday = journey.Monday, 
                Tuesday = journey.Tuesday, 
                Wednesday = journey.Wednesday,
                Thursday = journey.Thursday,
                Friday = journey.Friday,
                Saturday = journey.Saturday,
                Sunday = journey.Sunday
            };
        }
    }
}
