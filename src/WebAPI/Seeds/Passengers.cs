using WebAPI.Models;

namespace WebAPI.Seeds
{
    public static partial class SeedData
    {
        public static List<Passenger> GetPassengers(List<User> users)
        {
            return new List<Passenger>
            {
                new Passenger
                {
                    UserId = users.Where(user => user.FirstName == "Navruz").First().Id,
                },
            
                new Passenger
                {
                    UserId = users.Where(user => user.FirstName == "Jasur").First().Id,
                },

                new Passenger
                {
                    UserId = users.Where(user => user.FirstName == "Strange").First().Id,
                },

                new Passenger
                {
                    UserId = users.Where(user => user.FirstName == "Passenger").First().Id,
                },

                new Passenger
                {
                    UserId = users.Where(user => user.FirstName == "Iampass").First().Id,
                },
            };
        }
    }
}