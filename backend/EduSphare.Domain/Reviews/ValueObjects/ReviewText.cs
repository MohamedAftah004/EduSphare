using EduSphare.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Reviews.ValueObjects
{
    public sealed class ReviewText : ValueObject
    {
        private ReviewText() { }

        public string Value { get; }

        private ReviewText(string value)
        {
            Value = value;
        }

        public static ReviewText Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Review cannot be empty.");
            }

            if (value.Length > 2000)
            {
                throw new ArgumentException(
                    "Review is too long.");
            }

            return new ReviewText(value.Trim());
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
