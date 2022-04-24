using WebAPI.Models;

namespace WebAPI.Seeds
{
    public static partial class SeedData
    {
        public static List<Vehicle> GetVehicles()
        {
            return new List<Vehicle>
            {
                new Vehicle
                {
                    Model = "Nexia",
                    MaxSeats = 4,
                    Mark = "Shevrolet"
                },
            
                new Vehicle
                {
                    Model = "Damas",
                    MaxSeats = 6,
                    Mark = "Shevrolet"
                },
            };
        }
    }
}