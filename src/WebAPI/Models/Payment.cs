
using WebAPI.Enums;

namespace WebAPI.Models
{
    public class Payment : BaseEntity
    {
        public DateTimeOffset Date { get; set; }
        public decimal Amount { get; set; }
        public PaymentType PaymentType { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }
    }
}
