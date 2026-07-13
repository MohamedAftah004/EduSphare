using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common;

namespace EduSphare.Domain.Users.VOs
{
    public sealed class Name : ValueObject
    {
        public string Value { get; }

        private Name(string value)
        {
            Value = value;
        }

        public static Name Create(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }

            if (name.Length < 3)
            {
                throw new ArgumentException(
                    "Name must be at least 3 characters.",
                    nameof(name));
            }

            if (name.Length > 30)
            {
                throw new ArgumentException(
                    "Name must be between 3 and 30 characters.",
                    nameof(name));
            }

            return new Name(name);
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
