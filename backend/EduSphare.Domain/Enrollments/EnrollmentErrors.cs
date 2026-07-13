using EduSphare.Domain.Common;

namespace EduSphare.Domain.Enrollments;

public static class EnrollmentErrors
{
    public static readonly Error NotFound =
        new(
            "Enrollment.NotFound",
            "Enrollment was not found.");

    public static readonly Error AlreadyEnrolled =
        new(
            "Enrollment.AlreadyEnrolled",
            "Student is already enrolled in this course.");

    public static readonly Error LessonProgressNotFound =
        new(
            "Enrollment.LessonProgressNotFound",
            "Lesson progress was not found.");

    public static readonly Error CertificateNotFound =
        new(
            "Enrollment.CertificateNotFound",
            "Certificate was not found.");

    public static readonly Error CourseNotCompleted =
        new(
            "Enrollment.CourseNotCompleted",
            "Course has not been completed yet.");
}