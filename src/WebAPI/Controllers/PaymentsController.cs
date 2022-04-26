
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.ReadDtos;

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
        public ActionResult<IEnumerable<PaymentReadDto>> GetPayments()
        {
            return Ok(_mapper.Map<IEnumerable<PaymentReadDto>>(_context.Payments.ToList()));
        }

        [HttpGet("{id}", Name = "GetPaymentById")]
        public ActionResult<PaymentReadDto> GetPaymentById(int id)
        {
            var payment = _context.Payments.FirstOrDefault(payment => payment.Id == id);
            if (payment != null)
            {
                return Ok(_mapper.Map<OrderReadDto>(payment));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<PaymentReadDto>> CreatePayment([FromBody] PaymentCreateDto paymentCreateDto)
        {
            var payment = _mapper.Map<Payment>(paymentCreateDto);
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            var paymentReadDto = _mapper.Map<PaymentReadDto>(payment);
            return CreatedAtRoute(nameof(GetPaymentById), new { Id = paymentReadDto.Id }, paymentReadDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PaymentReadDto>> DeletePayment(int id)
        {
            var payment = _context.Payments.FirstOrDefault(payment => payment.Id == id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
                return Ok(_mapper.Map<PaymentReadDto>(payment));
            }
            return NotFound();
        }
    }
}