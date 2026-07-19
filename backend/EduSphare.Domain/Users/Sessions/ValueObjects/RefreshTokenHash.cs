using EduSphare.Domain.Common;

namespace EduSphare.Domain.Users.Sessions.ValueObjects
{
    public sealed class RefreshTokenHash : ValueObject
    {

        public string Value { get; }

        private RefreshTokenHash(string value)
        {
            Value = value;
        }

        public static RefreshTokenHash Create(string value)
        {

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Refresh token cannot be empty.",
                    nameof(value));
            }

            return new RefreshTokenHash(value);
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
}
