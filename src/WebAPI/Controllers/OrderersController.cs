
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.ReadDtos;

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
        public ActionResult<IEnumerable<OrdererReadDto>> GetOrderers()
        {
            return Ok(_mapper.Map<IEnumerable<OrdererReadDto>>(_context.Orderers.ToList()));
        }

        [HttpGet("{id}", Name = "GetOrdererById")]
        public ActionResult<OrdererReadDto> GetOrdererById(int id)
        {
            var orderer = _context.Orderers.FirstOrDefault(orderer => orderer.Id == id);
            if (orderer != null)
            {
                return Ok(_mapper.Map<OrdererReadDto>(orderer));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<OrdererReadDto>> CreateOrderer([FromBody] OrdererCreateDto ordererCreateDto)
        {
            var orderer = _mapper.Map<Orderer>(ordererCreateDto);
            _context.Orderers.Add(orderer);
            await _context.SaveChangesAsync();

            var ordererReadDto = _mapper.Map<OrdererReadDto>(orderer);
            return CreatedAtRoute(nameof(GetOrdererById), new { Id = ordererReadDto.Id }, ordererReadDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<OrdererReadDto>> DeleteOrderer(int id)
        {
            var orderer = _context.Orderers.FirstOrDefault(orderer => orderer.Id == id);
            if (orderer != null)
            {
                _context.Orderers.Remove(orderer);
                await _context.SaveChangesAsync();
                return Ok(_mapper.Map<OrdererReadDto>(orderer));
            }
            return NotFound();
        }
    }
}