
namespace WebAPI.Models
{
    public class Vehicle : BaseEntity
    {
        public string? Vin { get; set; }
        public int MaxSeats { get; set; }
        public string Model { get; set; }
        public string Mark { get; set; }
        public string? LicensePlateNumber { get; set; }
        public ICollection<Driver> Drivers { get; set; } = new List<Driver>();
    }
}