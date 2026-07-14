using EduSphare.Domain.Common;
using EduSphare.Domain.Common.ValueObjects;

namespace EduSphare.Domain.Users.Profiles
{
    public sealed class InstructorProfile : AuditableEntity
    {
        private InstructorProfile() { }

        public ImageUrl? ProfileImageUrl { get; private set; }
        public string HeadLine { get; private set; }
        public string? Bio { get; private set; }
        public int ExperienceYears { get; private set; }
        public int CountryId { get; private set; }
        public int NumberOfStudents { get; private set; }

        public Guid UserId { get; private set; }
        public User User { get; private set; } = null!;


        //-------- Behavior methods
        //create InstructorProfile factory 
        public static InstructorProfile Create(Guid userId, ImageUrl? profileImageUrl, string headLine, string? bio, int experienceYears)
        {
            EnsureValidExperience(experienceYears);

            return new InstructorProfile
            {
                UserId = userId,
                ProfileImageUrl = profileImageUrl,
                HeadLine = headLine,
                Bio = bio,
                ExperienceYears = experienceYears,
                NumberOfStudents = 0
            };
        }

        //update profile
        public void UpdateProfile(ImageUrl? profileImageUrl, string headLine, string? bio, int experienceYears)
        {
            EnsureValidExperience(experienceYears);

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


        public void IncrementExperienceYears()
        {
            EnsureValidExperience(ExperienceYears);

            ExperienceYears++;
            SetUpdated();
        }

        public void DecrementExperienceYears()
        {
            if (ExperienceYears > 0)
            {
                ExperienceYears--;
                SetUpdated();
            }
            else
            {
                throw new InvalidOperationException("Experience years must be between 0 and 70 years");
            }
        }


        #region Helper Functions


        private static void EnsureValidExperience(int expYears)
        {

            if (expYears > 70)
                throw new InvalidOperationException("Experience years must be between 0 and 70 years");
        }
        #endregion

    }
}
