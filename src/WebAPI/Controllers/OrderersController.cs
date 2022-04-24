
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrderersController : ControllerBase
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrderersController(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Orderer>> GetOrderers()
        {
            return Ok(_context.Orderers.ToList());
        }

        [HttpGet("{id}", Name = "GetOrdererById")]
        public ActionResult<Orderer> GetOrdererById(int id)
        {
            var orderer = _context.Orderers.FirstOrDefault(orderer => orderer.Id == id);
            if (orderer != null)
            {
                return Ok(orderer);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Orderer>> CreateOrderer([FromBody] OrdererCreateDto ordererCreateDto)
        {
            var orderer = _mapper.Map<Orderer>(ordererCreateDto);
            _context.Orderers.Add(orderer);
            await _context.SaveChangesAsync();

            return CreatedAtRoute(nameof(GetOrdererById), new { Id = orderer.Id }, orderer);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Orderer>> DeleteOrderer(int id)
        {
            var orderer = _context.Orderers.FirstOrDefault(orderer => orderer.Id == id);
            if (orderer != null)
            {
                _context.Orderers.Remove(orderer);
                await _context.SaveChangesAsync();
                return orderer;
            }
            return NotFound();
        }
    }
}