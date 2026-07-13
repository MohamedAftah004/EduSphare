using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common;
using EduSphare.Domain.Common.ValueObjects;

namespace EduSphare.Domain.Users.Profiles
{
    public sealed class InstructorProfile : AuditableEntity
    {
        private InstructorProfile(){}

       public ImageUrl? ProfileImageUrl { get; private set; }
       public string HeadLine { get; private set; }
       public string? Bio { get; private set; }
       public int ExperienceYears { get;private set; }
       public int CountryId { get; private set; }

        //-------- Behavior methods
        //create InstructorProfile factory 
        public static InstructorProfile Create(ImageUrl? profileImageUrl, string headLine, string? bio, int experienceYears)
        {
            return new InstructorProfile
            {
                ProfileImageUrl = profileImageUrl,
                HeadLine = headLine,
                Bio = bio,
                ExperienceYears = experienceYears
            };
        }

        //update profile
        public void UpdateProfile(ImageUrl? profileImageUrl, string headLine, string? bio, int experienceYears)
        {
            ProfileImageUrl = profileImageUrl;
            HeadLine = headLine;
            Bio = bio;
            ExperienceYears = experienceYears;
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

        //change country
        public void ChangeCountry(int countryId)
        {
            CountryId = countryId;
            SetUpdated();
        }

    }
}
