using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trucks.Domain.Models;

namespace Trucks.Data.Configurations
{
    /// <summary>
    /// Class to configures Truck entity.
    /// </summary>
    public class TruckConfiguration
         : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder
                .ToTable("Trucks");

            builder
                .HasKey(t => t.Id);

            builder
                .Property(t => t.Chassis)
                .IsRequired()
                .HasMaxLength(17);

            builder
                .Property(t => t.Model)
                .IsRequired();

            builder
                .Property(t => t.ModelComplement)
                .HasMaxLength(100);

            builder
                .Property(t => t.Year)
                .IsRequired();

            builder
                .Property(t => t.ModelYear)
                .IsRequired();
        }
    }
}
