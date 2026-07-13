using EduSphare.Domain.Common;

namespace EduSphare.Domain.Courses.Modules;

public static class ModuleErrors
{
    public static readonly Error LessonAlreadyExists =
        new("Modules.LessonAlreadyExists",
            "Lesson already exists.");

    public static readonly Error LessonNotFound =
        new("Modules.LessonNotFound",
            "Lesson not found.");
}