using WebAPI.Models;

namespace WebAPI.ReadDtos
{
    public class DriverReadDto
    {
        public int Id { get; set; }        
        public int UserId { get; set; }
        public UserReadDto User { get; set; }
    }
}
