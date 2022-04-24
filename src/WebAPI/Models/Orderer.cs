namespace WebAPI.Models
{
    public class Orderer : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
