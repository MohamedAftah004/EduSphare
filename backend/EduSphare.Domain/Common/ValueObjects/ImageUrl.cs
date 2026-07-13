using EduSphare.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Common.ValueObjects
{
    public sealed class ImageUrl : ValueObject
    {
        public string Value { get; }

        private ImageUrl(string value)
        {
            Value = value;
        }

        public static ImageUrl Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Image url cannot be empty.",
                    nameof(value));
            }

            if (!Uri.IsWellFormedUriString(value, UriKind.Absolute))
            {
                throw new ArgumentException(
                    "Invalid image url.",
                    nameof(value));
            }

            return new ImageUrl(value);
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
