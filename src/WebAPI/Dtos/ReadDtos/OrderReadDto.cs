using WebAPI.Models;

namespace WebAPI.ReadDtos
{
    public class OrderReadDto
    {
        public int Id { get; set; }        
        public int? OrderNumber { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset DepartureDate { get; set; }
        public string SourceCity { get; set; }
        public string DestinationCity { get; set; }
        public decimal Price { get; set; }
        public int? AvailablSeats { get; set; }
        public bool IsClosed { get; set; }
        public ICollection<OrdererReadDto> Orderers { get; set; }
        public int? DriverId { get; set; }
        public ICollection<PassengerReadDto> Passengers { get; set; }
    }
}
