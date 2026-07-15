using EduSphare.Domain.Verifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduSphare.Infrastructure.Persistence.Configurations;

public sealed class VerificationConfiguration
    : IEntityTypeConfiguration<Verification>
{
    public void Configure(EntityTypeBuilder<Verification> builder)
    {
        builder.ToTable("Verifications");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.CodeHash)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(x => x.Purpose)
            .HasConversion<string>()
            .HasMaxLength(50);

        builder.Property(x => x.ExpiresAt)
            .IsRequired();

        builder.Property(x => x.VerifiedAt);

        builder.HasIndex(x => new
        {
            x.UserId,
            x.Purpose
        });
    }
}