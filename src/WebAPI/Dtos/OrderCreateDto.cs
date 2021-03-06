namespace WebAPI.Dtos
{
    public class OrderCreateDto
    {
        public int? OrderNumber { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset DepartureDate { get; set; }
        public string SourceCity { get; set; }
        public string DestinationCity { get; set; }
        public decimal Price { get; set; }
        public int? AvailablSeats { get; set; }
        public bool IsClosed { get; set; } = false;
        public int? DriverId { get; set; }  // if the orderer is a driver
    }
}
