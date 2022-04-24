using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Moderator> Moderators { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Orderer> Orderers { get; set; }
        public DbSet<PitStop> PitStops { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripPitStop> TripPitStops { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
