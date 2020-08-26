namespace MetroAPI.DTOs
{
    public class JourneyReadDto
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public bool BankHolidays { get; set; }
        public OperationDaysDto OperationDays { get; set; }

    }

    public class OperationDaysDto
    {
        public bool Monday { get; set; }

        public bool Tuesday { get; set; }

        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }

        public bool Friday { get; set; }

        public bool Saturday { get; set; }

        public bool Sunday { get; set; }
    }
}
