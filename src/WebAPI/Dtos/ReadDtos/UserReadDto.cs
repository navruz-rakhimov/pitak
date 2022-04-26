using WebAPI.Models;

namespace WebAPI.ReadDtos
{
    public class UserReadDto
    {
        public int Id { get; set; }        
        public string Ssn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset BirthDay { get; set; }
    }
}
