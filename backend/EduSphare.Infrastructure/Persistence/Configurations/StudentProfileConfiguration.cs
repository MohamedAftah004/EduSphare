using EduSphare.Domain.Users.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Infrastructure.Persistence.Configurations
{
    public sealed class StudentProfileConfiguration : IEntityTypeConfiguration<StudentProfile>
    {
        public void Configure(EntityTypeBuilder<StudentProfile> builder)
        {
            builder.ToTable("StudentProfiles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Bio)
                .HasMaxLength(1000);

            builder.Property(x => x.DateOfBirth)
                .IsRequired();

            builder.Property(x => x.CountryId)
                .IsRequired();

            builder.OwnsOne(x => x.ProfileImageUrl, image =>
            {
                image.Property(x => x.Value)
                    .HasColumnName("ProfileImageUrl")
                    .HasMaxLength(500)
                    .IsRequired(false);
            });

            builder.HasOne(x => x.User)
                .WithOne(x => x.StudentProfile)
                .HasForeignKey<StudentProfile>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
