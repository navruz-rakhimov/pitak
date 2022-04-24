
using WebAPI.Models;

namespace WebAPI.Seeds
{
    public static partial class SeedData
    {
        public static List<Driver> GetDrivers(List<User> users, List<Vehicle> vehicles)
        {
            return new List<Driver>
            {
                new Driver
                {
                    UserId = users.Where(user => user.FirstName == "Mukhammadsaid").First().Id,
                    Rating = 4.3,
                    Experience = 5,
                    Vehicle = vehicles.Where(v => v.Model == "Damas").First(),
                    DriverLicenseNumber = "124",
                },
            
                new Driver
                {
                    UserId = users.Where(user => user.FirstName == "Bekzod").First().Id,
                    Rating = 4.1,
                    Experience = 3,
                    Vehicle = vehicles.Where(v => v.Model == "Nexia").First(),
                    DriverLicenseNumber = "124",
                },
            };
        }
    }
}