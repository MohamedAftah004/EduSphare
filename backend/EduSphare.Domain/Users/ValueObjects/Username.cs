using EduSphare.Domain.Common;
using System.Text.RegularExpressions;

namespace EduSphare.Domain.Users.ValueObjects;

public sealed class Username : ValueObject
{
    public string Value { get; }

    private Username(string value)
    {
        Value = value;
    }

    public static Username Create(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException(
                "Username cannot be null or empty.",
                nameof(username));
        }

        if (username.Length < 3)
        {
            throw new ArgumentException(
                "Username must be at least 3 characters.",
                nameof(username));
        }

        if (username.Length > 30)
        {
            throw new ArgumentException(
                "Username cannot exceed 30 characters.",
                nameof(username));
        }

        if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
        {
            throw new ArgumentException(
                "Username can only contain letters, numbers and underscores.",
                nameof(username));
        }

        return new Username(username.Trim());
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString()
    {
        return Value;
    }
}