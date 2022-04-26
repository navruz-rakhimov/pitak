using WebAPI.Models;

namespace WebAPI.ReadDtos
{
    public class OrdererReadDto
    {
        public int Id { get; set; }        
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
