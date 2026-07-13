using EduSphare.Domain.Common;

namespace EduSphare.Domain.Users.Sessions.VO
{
    public sealed class RefreshToken : ValueObject
    {

        public string Value { get; }

        private RefreshToken(string value)
        {
            Value = value;
        }

        public static RefreshToken Create(string value)
        {

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Refresh token cannot be empty.",
                    nameof(value));
            }

            return new RefreshToken(value);
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
