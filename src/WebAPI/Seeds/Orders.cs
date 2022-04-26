using WebAPI.Models;

namespace WebAPI.Seeds
{
    public static partial class SeedData
    {
        public static List<Order> GetOrders(List<Orderer> orderers, List<Driver> drivers)
        {
            return new List<Order>
            {
                new Order
                {
                    OrderDate = DateTime.Now,
                    DepartureDate = DateTime.Now.AddDays(1),
                    SourceCity = "Tashkent",
                    DestinationCity = "Samarkand",
                    Price = 15000,
                    IsClosed = false,
                    Orderers = new List<Orderer> { orderers.Where(o => o.IsDriver == false).First() },
                },
            
                new Order
                {
                    OrderDate = DateTime.Now,
                    DepartureDate = DateTime.Now.AddDays(2),
                    SourceCity = "Tashkent",
                    DestinationCity = "Namangan",
                    AvailablSeats = 4,
                    Price = 20000,
                    DriverId = drivers.Where(driver => driver.Experience == 5).First().UserId,
                    Driver = drivers.Where(driver => driver.Experience == 5).First(),
                    IsClosed = false,
                    Orderers = new List<Orderer> { orderers.Where(o => o.IsDriver == true).First() }
                },
            };
        }
    }
}