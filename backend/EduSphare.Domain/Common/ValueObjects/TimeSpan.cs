using EduSphare.Domain.Common;

namespace EduSphare.Domain.Common.ValueObjects;

public sealed class Duration : ValueObject
{
    public TimeSpan Value { get; }
    private Duration(TimeSpan value)
    {
        Value = value;
    }

    public static Duration Create(TimeSpan value)
    {
        if (value <= TimeSpan.Zero)
            throw new ArgumentException("Duration must be greater than zero.");

        return new Duration(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator TimeSpan(Duration duration)
        => duration.Value;

    public static explicit operator Duration(TimeSpan value)
        => Create(value);
}