
namespace WebAPI.Models
{
    public class Moderator : BaseEntity
    {
        public int? Level { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}