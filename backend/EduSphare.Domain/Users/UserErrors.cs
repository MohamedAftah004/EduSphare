using EduSphare.Domain.Common;

namespace EduSphare.Domain.Users;

public static class UserErrors
{
    public static readonly Error InvalidCredentials =
        new(
            "Users.InvalidCredentials",
            "Invalid email or password.");

    public static readonly Error UserNotFound =
        new(
            "Users.UserNotFound",
            "User not found.");

    public static readonly Error EmailAlreadyVerified =
        new(
            "Users.EmailAlreadyVerified",
            "Email is already verified.");

    public static readonly Error EmailNotVerified =
        new(
            "Users.EmailNotVerified",
            "Email is not verified.");

    public static readonly Error UserAlreadySuspended =
        new(
            "Users.UserAlreadySuspended",
            "User is already suspended.");

    public static readonly Error UserNotSuspended =
        new(
            "Users.UserNotSuspended",
            "User is not suspended.");

    public static readonly Error UserDeleted =
        new(
            "Users.UserDeleted",
            "User has been deleted.");

    public static readonly Error PasswordMismatch =
        new(
            "Users.PasswordMismatch",
            "Current password is incorrect.");

    public static readonly Error SamePassword =
        new(
            "Users.SamePassword",
            "New password cannot be the same as the current password.");

    public static readonly Error EmailAlreadyInUse =
        new(
            "Users.EmailAlreadyInUse",
            "Email is already in use.");

    public static readonly Error UsernameAlreadyInUse =
        new(
            "Users.UsernameAlreadyInUse",
            "Username is already in use.");

    public static readonly Error StudentProfileAlreadyExists =
        new(
            "Users.StudentProfileAlreadyExists",
            "Student profile already exists.");

    public static readonly Error InstructorProfileAlreadyExists =
        new(
            "Users.InstructorProfileAlreadyExists",
            "Instructor profile already exists.");

    public static readonly Error AdminProfileAlreadyExists =
        new(
            "Users.AdminProfileAlreadyExists",
            "Admin profile already exists.");

    public static readonly Error InvalidRoleForStudentProfile =
        new(
            "Users.InvalidRoleForStudentProfile",
            "Only students can have a student profile.");

    public static readonly Error InvalidRoleForInstructorProfile =
        new(
            "Users.InvalidRoleForInstructorProfile",
            "Only instructors can have an instructor profile.");

    public static readonly Error InvalidRoleForAdminProfile =
        new(
            "Users.InvalidRoleForAdminProfile",
            "Only admins can have an admin profile.");
}