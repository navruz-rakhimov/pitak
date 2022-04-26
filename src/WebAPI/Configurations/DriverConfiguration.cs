using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Models;

namespace WebAPI.Configurations
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.ToTable("Drivers");

            builder
                .HasOne(driver => driver.User)
                .WithMany(user => user.Drivers)
                .HasForeignKey(driver => driver.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasIndex(driver => driver.UserId).IsUnique();
        }
    }
}
