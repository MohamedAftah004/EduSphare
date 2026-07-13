using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common;

namespace EduSphare.Domain.Courses.ValueObjects
{
    public sealed class CategoryName : ValueObject
    {
        public string Value { get; }

        private CategoryName(string value)
        {
            Value = value;
        }

        public static CategoryName Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Category name cannot be empty.",
                    nameof(value));
            }

            if (value.Length > 200)
            {
                throw new ArgumentException(
                    "Category name cannot exceed 200 characters.",
                    nameof(value));
            }

            return new CategoryName(value.Trim());
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;
    }
}
