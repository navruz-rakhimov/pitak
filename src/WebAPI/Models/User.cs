using Microsoft.AspNetCore.Identity;

namespace WebAPI.Models 
{
    public class User : IdentityUser<int>
    {
        public string Ssn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset BirthDay { get; set; }
        public ICollection<Driver> Drivers { get; set; }
        public ICollection<Passenger> Passengers { get; set; }
        public ICollection<Moderator> Moderators { get; set; }

    }
}