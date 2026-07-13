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
        public int NumberOfStudents { get; private set; }

        public static StudentProfile Create(ImageUrl? profileImageUrl, string? bio, DateTime dateOfBirth, int countryId)
        {
            return new StudentProfile
            {
                ProfileImageUrl = profileImageUrl,
                Bio = bio,
                DateOfBirth = dateOfBirth,
                CountryId = countryId,
                NumberOfStudents = 0
            };
        }


        // behavior methods
      
        //update profile
        public void UpdateProfile(ImageUrl? profileImageUrl, string? bio, DateTime dateOfBirth, int countryId)
        {
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
            DateOfBirth = dateOfBirth;
            SetUpdated();
        }

        //change country
        public void ChangeCountry(int countryId)
        {
            CountryId = countryId;
            SetUpdated();
        }

        //increment number of students
        public void IncrementNumberOfStudents()
        {
            NumberOfStudents++;
            SetUpdated();
        }

        //decrement number of students
        public void DecrementNumberOfStudents()
        {
            if (NumberOfStudents > 0)
            {
                NumberOfStudents--;
                SetUpdated();
            }
            else
            {
                throw new InvalidOperationException("Number of students cannot be less than zero.");
            }
        }


    }
}
