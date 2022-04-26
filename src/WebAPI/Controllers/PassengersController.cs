
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(_mapper.Map<IEnumerable<PassengerReadDto>>(_context.Passengers.ToList()));
        }

        [HttpGet("{id}", Name = "GetPassengerById")]
        public ActionResult<PassengerReadDto> GetPassengerById(int id)
        {
            var passenger = _context.Passengers.FirstOrDefault(passenger => passenger.Id == id);
            if (passenger != null)
            {
                return Ok(_mapper.Map<PassengerReadDto>(passenger));
            }
            return NotFound();
        }
    }
}