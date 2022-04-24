
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.Interfaces;
using WebAPI.Models;

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
        public ActionResult<IEnumerable<Driver>> GetDrivers()
        {
            return Ok(_context.Drivers.ToList());
        }

        [HttpGet("{id}", Name = "GetDriverById")]
        public ActionResult<Driver> GetDriverById(int id)
        {
            var driver = _context.Drivers.FirstOrDefault(driver => driver.Id == id);
            if (driver != null)
            {
                return Ok(driver);
            }
            return NotFound();
        }
    }
}