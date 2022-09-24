using MatchDataManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchDataManager.Infrastructure.Persistence.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("Locations");

        builder.HasKey(e => e.Id);

        builder.HasIndex(e => e.Name)
            .IsUnique();

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.City)
            .IsRequired()
            .HasMaxLength(55);
    }
}
