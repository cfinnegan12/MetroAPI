namespace MetroAPI.DTOs
{
    public class LocationReadDto
    {
        public int Id { get; set; }
        public string ShortForm { get; set; }
        public string FullForm { get; set; }
        public int GridEasting { get; set; }
        public int GridNorthing { get; set; }
    }
}
