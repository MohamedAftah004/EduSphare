using EduSphare.Domain.Common;
using System.Text.RegularExpressions;

namespace EduSphare.Domain.Courses.ValueObjects;

public sealed class Slug : ValueObject
{
    public string Value { get; }

    private Slug(string value)
    {
        Value = value;
    }

    public static Slug Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(
                "Slug cannot be empty.",
                nameof(value));
        }

        value = value.Trim().ToLowerInvariant();

        if (!Regex.IsMatch(value, @"^[a-z0-9-]+$"))
        {
            throw new ArgumentException(
                "Slug contains invalid characters.",
                nameof(value));
        }

        return new Slug(value);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}