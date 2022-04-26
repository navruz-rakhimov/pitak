
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
    public class DriversController : ControllerBase
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DriversController(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DriverReadDto>> GetDrivers()
        {
            return Ok(_mapper.Map<IEnumerable<DriverReadDto>>(_context.Drivers.ToList()));
        }

        [HttpGet("{id}", Name = "GetDriverById")]
        public ActionResult<DriverReadDto> GetDriverById(int id)
        {
            var driver = _context.Drivers.FirstOrDefault(driver => driver.Id == id);
            if (driver != null)
            {
                return Ok(_mapper.Map<DriverReadDto>(driver));
            }
            return NotFound();
        }

        [HttpPost("{id}/orders")]
        public async Task<ActionResult<OrderReadDto>> CreateOrder(int id, [FromBody]OrderCreateDto orderCreateDto)
        {
            var driver = _context.Drivers.Include(d => d.Orders).Include(d => d.Vehicle).Where(d => d.Id == id).FirstOrDefault();
            if (driver == null)
            {
                return NotFound();
            }
            
            var order = _mapper.Map<Order>(orderCreateDto);
            order.DriverId = driver.Id;
            order.AvailablSeats = driver.Vehicle.MaxSeats;
            order.Orderers.Add(new Orderer{ UserId = driver.UserId});
    
            _context.Orders.Add(order);
            driver.Orders.Add(order);
            
            await _context.SaveChangesAsync();

            var orderReadDto = _mapper.Map<OrderReadDto>(order);
            return Ok(orderReadDto);
        }
    }
}