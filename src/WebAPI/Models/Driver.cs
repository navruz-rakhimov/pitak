
namespace WebAPI.Models 
{
    public class Driver : BaseEntity
    {
        public string DriverLicenseNumber { get; set; }
        public double? Rating { get; set; }
        public int? Experience { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}