
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
            return Ok(_mapper.Map<IEnumerable<OrderReadDto>>(
                _context.Orders.Include(o => o.Orderers).Include(o => o.Passengers).ToList()));
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

        [HttpPost("{id:int}/passengers")]
        public async Task<ActionResult<OrderReadDto>> AcceptDriverOrder(int id, [FromBody]PassengerAddDto passengerAddDto)
        {
            var order = await _context.Orders.Include(o => o.Passengers).Include(o => o.Orderers).FirstOrDefaultAsync(order => order.Id == id);
            var passenger = await _context.Passengers.FirstOrDefaultAsync(passenger => passenger.Id == passengerAddDto.PassengerId);

            if (order == null || passenger == null)
            {
                return NotFound();
            }

            if (order.DriverId == null)
            {
                return BadRequest($"The order with id: {id} doesn't have a driver");
            }

            if (order.Passengers.Where(p => p.Id == passenger.Id).FirstOrDefault() != null)
            {
                return BadRequest("You have already accepted this order");
            }

            if (order.AvailablSeats == 0)
            {
                return BadRequest("No available seats");
            }
            order.AvailablSeats -= 1;
            order.Passengers.Add(passenger);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<OrderReadDto>(order));
        }

        [HttpPost("{id:int}/driver")]
        public async Task<ActionResult<OrderReadDto>> AcceptPassengerOrder(int id, [FromBody]DriverAddDto DriverAddDto)
        {
            var order = await _context.Orders.Include(o => o.Passengers).Include(o => o.Orderers).FirstOrDefaultAsync(order => order.Id == id);
            var driver = await _context.Drivers.Include(d => d.Vehicle).FirstOrDefaultAsync(driver => driver.Id == DriverAddDto.DriverId);

            if (order == null || driver == null)
            {
                return NotFound();
            }

            if (order.DriverId != null)
            {
                return BadRequest("This order already has a driver");
            }

            order.DriverId = driver.Id;
            order.AvailablSeats = driver.Vehicle.MaxSeats;
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<OrderReadDto>(order));
        }
    }
}