
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UsersController(IApplicationDbContext context, IMapper mapper, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_userManager.Users.ToList());
        }

        [HttpGet("{id:int}", Name = "GetUserById")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _userManager.Users.FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }
    }
}