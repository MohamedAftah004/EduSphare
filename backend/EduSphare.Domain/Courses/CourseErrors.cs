using EduSphare.Domain.Common;

namespace EduSphare.Domain.Courses;

public static class CourseErrors
{
    public static readonly Error ModuleAlreadyExists =
        new("Courses.ModuleAlreadyExists", "Module already exists.");

    public static readonly Error ModuleNotFound =
        new("Courses.ModuleNotFound", "Module not found.");

    public static readonly Error OnlyDraftCoursesCanBePublished =
        new("Courses.OnlyDraftCoursesCanBePublished",
            "Only draft courses can be published.");

    public static readonly Error OnlyPublishedCoursesCanBeUnpublished =
        new("Courses.OnlyPublishedCoursesCanBeUnpublished",
            "Only published courses can be unpublished.");

    public static readonly Error OnlyPublishedCoursesCanBeArchived =
        new("Courses.OnlyPublishedCoursesCanBeArchived",
            "Only published courses can be archived.");

    public static readonly Error CourseMustContainAtLeastOneModule =
        new("Courses.CourseMustContainAtLeastOneModule",
            "Course must contain at least one module.");

    public static readonly Error CourseMustContainAtLeastOneLesson =
        new("Courses.CourseMustContainAtLeastOneLesson",
            "Course must contain at least one lesson.");
}