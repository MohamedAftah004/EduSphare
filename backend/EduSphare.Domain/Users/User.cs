using EduSphare.Domain.Common;
using EduSphare.Domain.Users.Profiles;
using EduSphare.Domain.Users.ValueObjects;

namespace EduSphare.Domain.Users
{
    public sealed class User : AggregateRoot
    {

        private User()
        {
        }

        public Name FirstName { get; private set; }
        public Name LastName { get; private set; }
        public Username UserName { get; private set; }
        public Email Email { get; private set; }
        public PasswordHash PasswordHash { get; private set; }
        public UserStatus Status { get; private set; }
        public UserRole Role { get; private set; }
        public DateTime EmailActivatedAt { get; private set; }


        //navigation properties
        public StudentProfile? StudentProfile { get; private set; }

        public InstructorProfile? InstructorProfile { get; private set; }

        public AdminProfile? AdminProfile { get; private set; }





        #region User Behaviors 

        //create User factory method
        public static User Create(Name firstName, Name lastName, Username username , Email email, PasswordHash passwordHash, UserRole role)
        {
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = username,
                Email = email,
                PasswordHash = passwordHash,
                Status = UserStatus.PendingEmailVerification,
                Role = role,
                EmailActivatedAt = DateTime.MinValue
            };
            return user;
        }

        //activate email
        public void ActivateEmail()
        {
            if (Status != UserStatus.PendingEmailVerification)
            {
                throw new InvalidOperationException(
                    "User cannot activate email in the current state.");
            }

            Status = UserStatus.Active;
            EmailActivatedAt = DateTime.UtcNow;
        }

        //deactivate
        public void Deactivate()
        {
            if (Status != UserStatus.Active)
            {
                throw new InvalidOperationException("Only active users can be suspended.");
            }

            Status = UserStatus.Suspended;
        }

        //activate
        public void Activate()
        {
            if (Status != UserStatus.Suspended)
            {
                throw new InvalidOperationException("User is not suspended.");
            }

            Status = UserStatus.Active;
        }

        public void MarkAsDeleted()
        {
            if (Status != UserStatus.Suspended)
                throw new InvalidOperationException(
                    "Only suspended users can be deleted.");

            Status = UserStatus.Deleted;
        }


        //change password
        public void ChangePassword(PasswordHash newPasswordHash)
        {
            if (newPasswordHash == null)
            {
                throw new ArgumentNullException(
                    "New password hash cannot be null.",
                    nameof(newPasswordHash));
            }

            if (Status != UserStatus.Active)
            {
                throw new InvalidOperationException(
                    "Only active users can change password.");
            }

            PasswordHash = newPasswordHash;
        }

        //change role
        public void ChangeRole(UserRole role)
        {
            if (Status == UserStatus.Deleted)
            {
                throw new InvalidOperationException(
                    "Cannot change role for a deleted user.");
            }

            if (Role == role)
            {
                throw new InvalidOperationException(
                    "User already has this role.");
            }

            Role = role;
        }

        //change name
        public void ChangeName(Name firstName, Name lastName)
        {
            if (Status == UserStatus.Deleted)
            {
                throw new InvalidOperationException(
                    "Cannot update name for a deleted user.");
            }

            FirstName = firstName;
            LastName = lastName;
        }

        //change email
        public void ChangeEmail(Email email)
        {
            if (Status == UserStatus.Deleted)
            {
                throw new InvalidOperationException(
                    "Cannot update email for a deleted user.");
            }

            if (Email == email)
            {
                throw new InvalidOperationException(
                    "Email is already assigned to the user.");
            }

            Email = email;
            Status = UserStatus.PendingEmailVerification;
            EmailActivatedAt = DateTime.MinValue;
        }
        #endregion




        #region Student Behaviors 

        //create student profile
        public void CreateStudentProfile(StudentProfile profile)
        {
            ArgumentNullException.ThrowIfNull(profile);

            if (Role != UserRole.Student)
            {
                throw new InvalidOperationException(
                    "Only users with the Student role can have a student profile.");
            }


            if (StudentProfile != null)
            {
                throw new InvalidOperationException(
                    "Student profile already exists for this user.");
            }

            StudentProfile = profile;
        }
        #endregion


        #region Instructor Behaviors 

        //create instructor profile
        public void CreateInstructorProfile(InstructorProfile profile)
        {
            ArgumentNullException.ThrowIfNull(profile);

            if (Role != UserRole.Instructor)
            {
                throw new InvalidOperationException(
                    "Only users with the Instructor role can have an instructor profile.");
            }


            if (InstructorProfile != null)
            {
                throw new InvalidOperationException(
                    "Instructor profile already exists for this user.");
            }

            InstructorProfile = profile;
        }
        #endregion


        #region Admin Behaviors 

        //create Admin profile
        public void CreateAdminProfile(AdminProfile profile)
        {
            ArgumentNullException.ThrowIfNull(profile);

            if (Role != UserRole.Admin)
            {
                throw new InvalidOperationException(
                    "Only users with the Admin role can have an admin profile.");
            }


            if (AdminProfile != null)
            {
                throw new InvalidOperationException(
                    "Admin profile already exists for this user.");
            }

            AdminProfile = profile;
        }
        #endregion




    }
}
