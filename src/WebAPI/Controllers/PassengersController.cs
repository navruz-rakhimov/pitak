
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Dtos;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.ReadDtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PassengersController : ControllerBase
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PassengersController(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PassengerReadDto>> GetPassengers()
        {
            return Ok(_mapper.Map<IEnumerable<PassengerReadDto>>(_context.Passengers.Include(d => d.User).ToList()));
        }

        [HttpGet("{id}", Name = "GetPassengerById")]
        public ActionResult<PassengerReadDto> GetPassengerById(int id)
        {
            var passenger = _context.Passengers.Include(d => d.User).FirstOrDefault(passenger => passenger.Id == id);
            if (passenger != null)
            {
                return Ok(_mapper.Map<PassengerReadDto>(passenger));
            }
            return NotFound();
        }

        [HttpPost("{id}/orders")]
        public async Task<ActionResult<OrderReadDto>> CreateOrder(int id, [FromBody]OrderCreateDto orderCreateDto)
        {
            var passenger = _context.Passengers.Include(p => p.Orders).Where(p => p.Id == id).FirstOrDefault();
            if (passenger == null)
            {
                return NotFound();
            }
            
            var order = _mapper.Map<Order>(orderCreateDto);
            order.Orderers.Add(new Orderer{ UserId = passenger.UserId});
    
            _context.Orders.Add(order);
            passenger.Orders.Add(order);
            
            await _context.SaveChangesAsync();

            var orderReadDto = _mapper.Map<OrderReadDto>(order);
            return Ok(orderReadDto);
        }
    }
}