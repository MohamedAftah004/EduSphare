using EduSphare.Domain.Common;
using EduSphare.Domain.Common.ValueObjects;
using EduSphare.Domain.Users.Profiles.VO;

namespace EduSphare.Domain.Users.Profiles
{
    public sealed class AdminProfile : AuditableEntity

    {
        private AdminProfile()
        {
        }

        public ImageUrl? ProfileImageUrl { get; private set; }
        public EmployeeCode EmployeeCode { get; private set; }
        public NationalId NationalId { get; private set; }
        public DateTime HireDate { get; private set; }


        public Guid UserId { get; private set; }
        public User User { get; private set; } = null!;


        //-------- Behavior methods
        //create AdminProfile  

        public static AdminProfile Create(
            Guid userId,
            ImageUrl? profileImageUrl,
            EmployeeCode employeeCode,
            NationalId nationalId)
        {
            return new AdminProfile
            {
                UserId = userId,
                ProfileImageUrl = profileImageUrl,
                EmployeeCode = employeeCode,
                NationalId = nationalId,
                HireDate = DateTime.UtcNow
            };
        }


       
        //update profile image
        public void UpdateProfileImage(ImageUrl? profileImageUrl)
        {
            ProfileImageUrl = profileImageUrl;
            SetUpdated();
        }


    }
}
