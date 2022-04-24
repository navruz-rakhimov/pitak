
namespace WebAPI.Models 
{
    public class Driver : BaseEntity
    {
        public string DriverLicenseNumber { get; set; }
        public double? Rating { get; set; }
        public int? Experience { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}