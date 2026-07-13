using EduSphare.Domain.Common;

namespace EduSphare.Domain.Courses.Modules.Lessons;

public static class LessonErrors
{
    public static readonly Error InvalidOrderNumber =
        new("Lessons.InvalidOrderNumber",
            "Order number must be greater than zero.");

    public static readonly Error InvalidDuration =
        new("Lessons.InvalidDuration",
            "Duration must be greater than zero.");
}