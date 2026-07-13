using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common;

namespace EduSphare.Domain.Quizzes.ValueObjects
{
    public sealed class QuizTitle : ValueObject
    {
        public string Value { get; }

        private QuizTitle(string value)
        {
            Value = value;
        }

        public static QuizTitle Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Quiz title cannot be empty.",
                    nameof(value));
            }

            if (value.Length > 200)
            {
                throw new ArgumentException(
                    "Quiz title cannot exceed 200 characters.",
                    nameof(value));
            }

            return new QuizTitle(value.Trim());
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
