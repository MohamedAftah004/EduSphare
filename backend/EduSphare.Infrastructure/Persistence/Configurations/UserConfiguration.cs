using EduSphare.Domain.Users;
using EduSphare.Domain.Users.Profiles;
using EduSphare.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EduSphare.Infrastructure.Persistence.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.ToTable("Users");
            builder.HasKey(x => x.Id);


            builder.Property(x => x.FirstName)
                .HasConversion(
                    x => x.Value,
                    Value => Name.Create(Value)
                ).HasMaxLength(30).IsRequired();

            builder.Property(x => x.LastName)
                .HasConversion(
                x => x.Value,
                Value => Name.Create(Value)
            ).HasMaxLength(30).IsRequired();

            builder.Property(x => x.UserName)
                .HasConversion(
                    x => x.Value,
                    Value => Username.Create(Value)
                ).HasMaxLength(30).IsRequired();

            builder.Property(x => x.Email)
                .HasConversion(
                    x => x.Value,
                    Value => Email.Create(Value)
                ).HasMaxLength(255).IsRequired();

            //indexing
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.PasswordHash)
                .HasConversion(
                    x => x.Value,
                    Value => PasswordHash.Create(Value)
                ).HasMaxLength(128).IsRequired();

            builder.Property(x => x.Role)
                .HasConversion<string>().HasMaxLength(30);

            builder.Property(x => x.EmailActivatedAt);



            builder.HasOne(x => x.StudentProfile)
                .WithOne(x => x.User)
                .HasForeignKey<StudentProfile>(x => x.UserId);

            builder.HasOne(x=>x.InstructorProfile)
                .WithOne(x=>x.User)
                .HasForeignKey<InstructorProfile>(x => x.UserId);

            builder.HasOne(x=>x.AdminProfile)
                .WithOne(x=>x.User)
                .HasForeignKey<AdminProfile>(x => x.UserId);

        }
    }
}
