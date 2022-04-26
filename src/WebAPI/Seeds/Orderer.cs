using WebAPI.Models;

namespace WebAPI.Seeds
{
    public static partial class SeedData
    {
        public static List<Orderer> GetOrderers(List<User> users)
        {
            return new List<Orderer>
            {
                new Orderer
                {
                    UserId = users.Where(user => user.FirstName == "Navruz").First().Id,
                    IsDriver = false
                },
            
                new Orderer
                {
                    UserId = users.Where(user => user.FirstName == "Mukhammadsaid").First().Id,
                    IsDriver = true
                },
            };
        }
    }
}