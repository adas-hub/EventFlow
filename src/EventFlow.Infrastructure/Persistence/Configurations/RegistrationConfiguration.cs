using EventFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventFlow.Infrastructure.Persistence.Configurations;

public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
{
    public void Configure(EntityTypeBuilder<Registration> builder)
    {
        builder.Property(r => r.Id).IsRequired();
        builder.Property(r => r.CreatedDate).HasDefaultValueSql("GETUTCDATE()");
        builder.Property(r => r.UpdatedDate).HasDefaultValueSql("GETUTCDATE()");
        builder.Property(r => r.Status).HasConversion<string>();
    }
}
