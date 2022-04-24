namespace WebAPI.Models
{
    public class TripPitStop : BaseEntity
    {
        public int Duration { get; set; }
        public string Reason { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; }
        public int PitStopId { get; set; }
        public PitStop PitStop { get; set; }
    }
}
