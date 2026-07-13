using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common;

namespace EduSphare.Domain.Quizzes.QuizQuestion.ValueObjects
{
    public sealed class QuestionText : ValueObject
    {

        public string Value { get; }
        private QuestionText(string value) { Value = value; }


        public static QuestionText Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Question text cannot be empty.",
                    nameof(value));
            }

            if (value.Length > 500)
            {
                throw new ArgumentException(
                    "Question text cannot exceed 500 characters.",
                    nameof(value));
            }

            return new QuestionText(value.Trim());
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
