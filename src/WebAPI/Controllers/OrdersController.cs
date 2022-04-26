
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
    public class OrdersController : ControllerBase
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrdersController(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderReadDto>> GetOrders()
        {
            return Ok(_mapper.Map<IEnumerable<OrderReadDto>>(_context.Orders.Include(o => o.Orderers).ToList()));
        }

        [HttpGet("{id}", Name = "GetOrderById")]
        public ActionResult<OrderReadDto> GetOrderById(int id)
        {
            var order = _context.Orders.FirstOrDefault(order => order.Id == id);
            if (order != null)
            {
                return Ok(_mapper.Map<OrderReadDto>(order));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<OrderReadDto>> CreateOrder([FromBody]OrderCreateDto orderCreateDto)
        {
            var order = _mapper.Map<Order>(orderCreateDto);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            var orderReadDto = _mapper.Map<OrderReadDto>(order);
            return CreatedAtRoute(nameof(GetOrderById), new { Id = orderReadDto.Id }, orderReadDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<OrderReadDto>> UpdateOrder(int id, [FromBody] OrderCreateDto orderCreateDto)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(order => order.Id == id);
            if (order != null)
            {
                order = _mapper.Map<Order>(orderCreateDto);
                await _context.SaveChangesAsync();
                return Ok(_mapper.Map<OrderReadDto>(order));
            }
            return NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<OrderReadDto>> DeleteOrder(int id)
        {
            var order = _context.Orders.FirstOrDefault(order => order.Id == id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return Ok(_mapper.Map<OrderReadDto>(order));
            }
            return NotFound();
        }

        [HttpPost("{id:int}/passengers/{passengerId:int}")]
        public async Task<ActionResult<OrderReadDto>> AcceptOrder(int id, int passengerId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(order => order.Id == id);
            var passenger = await _context.Passengers.FirstOrDefaultAsync(passenger => passenger.Id == passengerId);

            if (order == null || passenger == null)
            {
                return NotFound();
            }

            order.Passengers.Add(passenger);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<OrderReadDto>(order));
        }
    }
}