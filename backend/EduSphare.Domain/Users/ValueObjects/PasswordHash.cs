using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common;

namespace EduSphare.Domain.Users.ValueObjects
{
    public sealed class PasswordHash : ValueObject
    {
        public string Value { get; }

        private PasswordHash(string value)
        {
            Value = value;
        }

        public static PasswordHash Create(string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                throw new ArgumentException(
                    "Password hash cannot be null or empty.",
                    nameof(passwordHash));
            }
            if (passwordHash.Length < 8)
            {
                throw new ArgumentException(
                    "Password hash must be at least 8 characters.",
                    nameof(passwordHash));
            }
            if (passwordHash.Length > 128)
            {
                throw new ArgumentException(
                    "Password hash cannot exceed 128 characters.",
                    nameof(passwordHash));
            }
            return new PasswordHash(passwordHash);
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
