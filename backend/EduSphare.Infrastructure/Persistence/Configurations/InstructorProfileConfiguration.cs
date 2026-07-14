using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common.ValueObjects;
using EduSphare.Domain.Users.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduSphare.Infrastructure.Persistence.Configurations
{
    public sealed class InstructorProfileConfiguration : IEntityTypeConfiguration<InstructorProfile>
    {
        public void Configure(EntityTypeBuilder<InstructorProfile> builder)
        {
            builder.ToTable("InstructorProfiles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.HeadLine)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Bio)
                .HasMaxLength(1000);

            builder.Property(x => x.ExperienceYears)
                .IsRequired();

            builder.Property(x => x.CountryId)
                .IsRequired();

            builder.Property(x => x.NumberOfStudents)
                .IsRequired();

            builder.OwnsOne(x => x.ProfileImageUrl, image =>
            {
                image.Property(x => x.Value)
                    .HasColumnName("ProfileImageUrl")
                    .HasMaxLength(500)
                    .IsRequired(false);
            });

            builder.HasOne(x => x.User)
                .WithOne(x => x.InstructorProfile)
                .HasForeignKey<InstructorProfile>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
