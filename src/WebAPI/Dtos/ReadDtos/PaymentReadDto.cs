using WebAPI.Enums;
using WebAPI.Models;

namespace WebAPI.ReadDtos
{
    public class PaymentReadDto
    {
        public int Id { get; set; }        
        public DateTimeOffset Date { get; set; }
        public decimal Amount { get; set; }
        public PaymentType PaymentType { get; set; }
        public int DriverId { get; set; }
        public int PassengerId { get; set; }
    }
}
