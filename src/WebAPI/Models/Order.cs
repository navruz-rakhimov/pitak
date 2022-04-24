namespace WebAPI.Models
{
    public class Order : BaseEntity
    {
        public int? OrderNumber { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset DepartureDate { get; set; }
        public string SourceCity { get; set; }
        public string DestinationCity { get; set; }
        public decimal Price { get; set; }
        public int? DriverId { get; set; }
        public Driver Driver { get; set; }
        public int AvailablSeats { get; set; }
        public bool IsClosed { get; set; } = false;
        public ICollection<Orderer> Orderers { get; set; }
        public ICollection<Passenger> Passengers { get; set; }
    }
}
