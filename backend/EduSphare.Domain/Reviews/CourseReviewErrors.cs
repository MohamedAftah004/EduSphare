using EduSphare.Domain.Common;

namespace EduSphare.Domain.Reviews;

public static class CourseReviewErrors
{
    public static readonly Error NotFound =
        new(
            "CourseReview.NotFound",
            "Course review was not found.");

    public static readonly Error AlreadyExists =
        new(
            "CourseReview.AlreadyExists",
            "Student has already reviewed this course.");

    public static readonly Error InvalidStars =
        new(
            "CourseReview.InvalidStars",
            "Stars must be between 1 and 5.");
}