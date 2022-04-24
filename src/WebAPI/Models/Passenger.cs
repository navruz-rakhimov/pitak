
namespace WebAPI.Models 
{
    public class Passenger : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}