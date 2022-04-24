namespace WebAPI.Models
{
    public class Trip : BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
