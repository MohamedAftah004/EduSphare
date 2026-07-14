using EduSphare.Domain.Users.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Infrastructure.Persistence.Configurations
{
    public sealed class AdminProfileConfiguration : IEntityTypeConfiguration<AdminProfile>
    {
        public void Configure(EntityTypeBuilder<AdminProfile> builder)
        {
            builder.ToTable("AdminProfiles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.HireDate)
                .IsRequired();

            builder.OwnsOne(x => x.ProfileImageUrl, image =>
            {
                image.Property(x => x.Value)
                    .HasColumnName("ProfileImageUrl")
                    .HasMaxLength(500)
                    .IsRequired(false);
            });

            builder.OwnsOne(x => x.EmployeeCode, employee =>
            {
                employee.Property(x => x.Value)
                    .HasColumnName("EmployeeCode")
                    .HasMaxLength(50)
                    .IsRequired();

                employee.HasIndex(x => x.Value)
                    .IsUnique();
            });

            builder.OwnsOne(x => x.NationalId, national =>
            {
                national.Property(x => x.Value)
                    .HasColumnName("NationalId")
                    .HasMaxLength(14)
                    .IsRequired();

                national.HasIndex(x => x.Value)
                    .IsUnique();
            });

            builder.HasOne(x => x.User)
                .WithOne(x => x.AdminProfile)
                .HasForeignKey<AdminProfile>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
