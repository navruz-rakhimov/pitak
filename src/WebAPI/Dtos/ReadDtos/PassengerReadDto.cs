using WebAPI.Models;

namespace WebAPI.ReadDtos
{
    public class PassengerReadDto
    {
        public int Id { get; set; }        
        public int UserId { get; set; }
        public UserReadDto User { get; set; }
    }
}
