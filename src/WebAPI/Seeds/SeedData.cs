
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Seeds
{
    public partial class SeedData
    {
        public const string DefaultPassword = "Pa$$w0rd";

        public static async Task SeedDataAsync(ApplicationDbContext context, UserManager<User> userManager)
        {
            await SeedData.AddUsers(userManager);
            await SeedData.AddVehicles(context);
            await SeedData.AddDrivers(context);
            await SeedData.AddPassengers(context);
            await SeedData.AddOrderers(context);
            await SeedData.AddOrders(context);
        }

        public static async Task AddUsers(UserManager<User> userManager)
        {
            if (!await userManager.Users.AnyAsync())
            {
                foreach (var user in GetUsers())
                {
                    await userManager.CreateAsync(user, DefaultPassword);
                }
            }
        }

        public static async Task AddVehicles(ApplicationDbContext context)
        {
            if (!await context.Vehicles.AnyAsync())
            {
                context.Vehicles.AddRange(GetVehicles());
                await context.SaveChangesAsync();
            }
        }

        public static async Task AddDrivers(ApplicationDbContext context)
        {
            if (!await context.Drivers.AnyAsync())
            {
                var users = await context.Users.ToListAsync();
                var vehicles = await context.Vehicles.ToListAsync();
                context.Drivers.AddRange(GetDrivers(users, vehicles));
                await context.SaveChangesAsync();
            }
        }

        public static async Task AddPassengers(ApplicationDbContext context)
        {
            if (!await context.Passengers.AnyAsync())
            {
                var users = await context.Users.ToListAsync();
                context.Passengers.AddRange(GetPassengers(users));
                await context.SaveChangesAsync();
            }
        }

        public static async Task AddOrderers(ApplicationDbContext context)
        {
            if (!await context.Orderers.AnyAsync())
            {
                var users = await context.Users.ToListAsync();
                context.Orderers.AddRange(GetOrderers(users));
                await context.SaveChangesAsync();
            }
        }

        public static async Task AddOrders(ApplicationDbContext context)
        {
            if (!await context.Orders.AnyAsync())
            {
                var orderers = await context.Orderers.ToListAsync();
                var drivers = await context.Drivers.ToListAsync();
                context.Orders.AddRange(GetOrders(orderers, drivers));
                await context.SaveChangesAsync();
            }
        }
    }
}