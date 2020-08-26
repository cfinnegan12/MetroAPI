namespace MetroAPI.DTOs
{
    public class StopReadDto
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string Time { get; set; }
        //O = Origin, I = Intermediate, D = Destination
        public char StopType { get; set; }
    }
}
