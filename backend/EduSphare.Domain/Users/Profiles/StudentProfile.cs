using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common;
using EduSphare.Domain.Common.ValueObjects;

namespace EduSphare.Domain.Users.Profiles
{
    public sealed class StudentProfile : AuditableEntity
    {
        private StudentProfile() { }


        public ImageUrl? ProfileImageUrl { get; private set; }
        public string? Bio { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public int CountryId { get; private set; }

        public Guid UserId { get; private set; }
        public User User { get; private set; } = null!;


        public static StudentProfile Create(Guid userId , ImageUrl? profileImageUrl, string? bio, DateTime dateOfBirth, int countryId)
        {
            EnsureValidDateOfBirth(dateOfBirth);


            return new StudentProfile
            {
                UserId = userId,
                ProfileImageUrl = profileImageUrl,
                Bio = bio,
                DateOfBirth = dateOfBirth,
                CountryId = countryId,
            };
        }


        // behavior methods
      
        //update profile
        public void UpdateProfile(ImageUrl? profileImageUrl, string? bio, DateTime dateOfBirth, int countryId)
        {
            EnsureValidDateOfBirth(dateOfBirth);

            ProfileImageUrl = profileImageUrl;
            Bio = bio;
            DateOfBirth = dateOfBirth;
            CountryId = countryId;
            SetUpdated();
        }

        //update bio
        public void UpdateBio(string bio)
        {
            Bio = bio;
            SetUpdated();
        }

        //update profile image
        public void UpdateProfileImage(ImageUrl? profileImageUrl)
        {
            ProfileImageUrl = profileImageUrl;
            SetUpdated();
        }

        //change date of birth
        public void ChangeDateOfBirth(DateTime dateOfBirth)
        {
            EnsureValidDateOfBirth(dateOfBirth);

            DateOfBirth = dateOfBirth;
            SetUpdated();
        }

        //change country
        public void ChangeCountry(int countryId)
        {
            CountryId = countryId;
            SetUpdated();
        }




        #region Helper Functions

        //helper functions


        private static void EnsureValidDateOfBirth(DateTime dateOfBirth)
        {
            if (dateOfBirth > DateTime.UtcNow.Date)
                throw new InvalidOperationException("Date of birth cannot be in the future.");
        }
        #endregion

    }
}
