
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    }
}