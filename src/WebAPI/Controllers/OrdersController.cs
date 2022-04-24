
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.Interfaces;
using WebAPI.Models;

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
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            return Ok(_context.Orders);
        }

        [HttpGet("{id}", Name = "GetOrderById")]
        public ActionResult<Order> GetOrderById(int id)
        {
            var order = _context.Orders.FirstOrDefault(order => order.Id == id);
            if (order != null)
            {
                return Ok(order);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder([FromBody]OrderCreateDto orderCreateDto)
        {
            var order = _mapper.Map<Order>(orderCreateDto);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtRoute(nameof(GetOrderById), new { Id = order.Id }, order);
        }
    }
}