using EduSphare.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Quizzes.QuizQuestion.ValueObjects
{
    public sealed class OptionText : ValueObject
    {
        public string Value { get; }

        private OptionText(string value)
        {
            Value = value;
        }

        public static OptionText Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Option text cannot be empty.",
                    nameof(value));
            }

            if (value.Length > 200)
            {
                throw new ArgumentException(
                    "Option text cannot exceed 200 characters.",
                    nameof(value));
            }

            return new OptionText(value.Trim());
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
