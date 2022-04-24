
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PaymentsController(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Payment>> GetPayments()
        {
            return Ok(_context.Payments.ToList());
        }

        [HttpGet("{id}", Name = "GetPaymentById")]
        public ActionResult<Payment> GetPaymentById(int id)
        {
            var payment = _context.Payments.FirstOrDefault(payment => payment.Id == id);
            if (payment != null)
            {
                return Ok(payment);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Payment>> CreatePayment([FromBody] PaymentCreateDto paymentCreateDto)
        {
            var payment = _mapper.Map<Payment>(paymentCreateDto);
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return CreatedAtRoute(nameof(GetPaymentById), new { Id = payment.Id }, payment);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Payment>> DeletePayment(int id)
        {
            var payment = _context.Payments.FirstOrDefault(payment => payment.Id == id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
                return payment;
            }
            return NotFound();
        }
    }
}