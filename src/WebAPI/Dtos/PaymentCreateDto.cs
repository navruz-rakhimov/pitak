using WebAPI.Enums;

namespace WebAPI.Dtos
{
    public class PaymentCreateDto
    {
        public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
        public decimal Amount { get; set; }
        public PaymentType PaymentType { get; set; }
        public int DriverId { get; set; }
        public int PassengerId { get; set; }
    }
}
