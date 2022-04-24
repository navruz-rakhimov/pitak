namespace WebAPI.Models
{
    public class Feedback : BaseEntity
    {
        public double Rating { get; set; }
        public string Content { get; set; }
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; }
    }
}
