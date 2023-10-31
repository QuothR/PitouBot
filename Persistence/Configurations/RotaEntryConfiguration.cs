using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class RotaEntryConfiguration : IEntityTypeConfiguration<RotaEntry>
{
    public void Configure(EntityTypeBuilder<RotaEntry> builder)
    {
        builder.HasKey(re => re.Id);
        builder.Property(re => re.Id).HasConversion(
            productId => productId.Value,
            value => new Id(value)
        );
        
        builder.HasMany<User>("Users") // Assuming Users is a private field
            .WithOne() // Since User doesn't have a navigation property back to RotaEntry
            .HasForeignKey("RotaEntryId"); // Foreign key in the User table
    }
}