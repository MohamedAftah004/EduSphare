using EduSphare.Domain.Users.Sessions;
using EduSphare.Domain.Users.Sessions.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduSphare.Infrastructure.Persistence.Configurations;

public sealed class UserSessionConfiguration : IEntityTypeConfiguration<UserSession>
{
    public void Configure(EntityTypeBuilder<UserSession> builder)
    {
        builder.ToTable("UserSessions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.RefreshTokenHash)
            .HasConversion(
                token => token.Value,
                value => RefreshTokenHash.Create(value))
            .HasMaxLength(64)
            .IsRequired();

        builder.HasIndex(x => x.RefreshTokenHash)
            .IsUnique();

        builder.Property(x => x.UserAgent)
            .HasMaxLength(1024);

        builder.Property(x => x.IpAddress)
            .HasMaxLength(50);

        builder.Property(x => x.DeviceName)
            .HasMaxLength(200);

        builder.Property(x => x.ExpiresAt)
            .IsRequired();

        builder.Property(x => x.RevokedAt);

        builder.Property(x => x.LastActivityAt)
            .IsRequired();
    }
}