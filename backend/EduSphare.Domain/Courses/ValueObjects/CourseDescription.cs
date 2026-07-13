using EduSphare.Domain.Common;

namespace EduSphare.Domain.Courses.ValueObjects;

public sealed class CourseDescription : ValueObject
{
    public string Value { get; }

    private CourseDescription(string value)
    {
        Value = value;
    }

    public static CourseDescription Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(
                "Course description cannot be empty.",
                nameof(value));
        }

        if (value.Length > 5000)
        {
            throw new ArgumentException(
                "Course description cannot exceed 5000 characters.",
                nameof(value));
        }

        return new CourseDescription(value.Trim());
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}