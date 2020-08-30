using System;

namespace MetroAPI.DTOs
{
    public class StopReadDTO
    {
        public int Id { get;}
        public int LocationId { get;}
        public int Time { get;}
        public char StopType { get;}

        public StopReadDTO(Models.Stop stop)
        {
            this.Id = stop.Id;
            this.LocationId = stop.Location.Id;
            this.StopType = stop.StopType;
            this.Time = TimeDto(stop.Time);
        }

        private int TimeDto(TimeSpan time)
        {
            int hours = time.Hours;
            int mins = time.Minutes;
            int result = (hours * 100) + mins;
            return result;
        }
    }
}
