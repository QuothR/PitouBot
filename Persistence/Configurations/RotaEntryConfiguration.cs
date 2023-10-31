using Domain.RotaEntries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class RotaEntryConfiguration : IEntityTypeConfiguration<RotaEntry>
{
    public void Configure(EntityTypeBuilder<RotaEntry> builder)
    {
        builder.HasKey(re => re.Id);
        builder.Property(re => re.Interval);
        builder.Property(re => re.Users);
    }
}