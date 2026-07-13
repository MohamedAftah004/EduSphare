using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common;

namespace EduSphare.Domain.Reviews.ValueObjects
{
    public sealed class ReviewStars : ValueObject
    {

        private ReviewStars() { }

        public int Value { get; }

        private ReviewStars(int value)
        {
            Value = value;
        }


        public static ReviewStars Create(int value)
        {
            if (value < 1 || value > 5)
            {
                throw new ArgumentException("Stars must be between 1 and 5.");
            }

            return new ReviewStars(value);
        }


        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
