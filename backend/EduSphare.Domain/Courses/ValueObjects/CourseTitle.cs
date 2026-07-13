using EduSphare.Domain.Common;

namespace EduSphare.Domain.Courses.ValueObjects;

public sealed class CourseTitle : ValueObject
{
    public string Value { get; }

    private CourseTitle(string value)
    {
        Value = value;
    }

    public static CourseTitle Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(
                "Course title cannot be empty.",
                nameof(value));
        }

        if (value.Length > 200)
        {
            throw new ArgumentException(
                "Course title cannot exceed 200 characters.",
                nameof(value));
        }

        return new CourseTitle(value.Trim());
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}