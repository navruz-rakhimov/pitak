using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Models;

namespace WebAPI.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");

            builder
                .HasOne(payment => payment.Passenger)
                .WithMany(passenger => passenger.Payments)
                .HasForeignKey(payment => payment.PassengerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(payment => payment.Driver)
                .WithMany(driver => driver.Payments)
                .HasForeignKey(payment => payment.DriverId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
