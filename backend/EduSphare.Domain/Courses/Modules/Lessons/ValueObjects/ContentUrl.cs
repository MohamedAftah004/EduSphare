using EduSphare.Domain.Common;

namespace EduSphare.Domain.Courses.Modules.Lessons.ValueObjects;

public sealed class ContentUrl : ValueObject
{
    public string Value { get; }

    private ContentUrl(string value)
    {
        Value = value;
    }

    public static ContentUrl Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Content URL cannot be empty.");

        if (!Uri.TryCreate(value, UriKind.Absolute, out _))
            throw new ArgumentException("Invalid content URL.");

        return new ContentUrl(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator string(ContentUrl contentUrl)
        => contentUrl.Value;

    public static explicit operator ContentUrl(string value)
        => Create(value);

    public override string ToString()
        => Value;
}