namespace WebAPI.Models
{
    public class Orderer : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public bool IsDriver { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
