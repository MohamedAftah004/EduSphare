using EduSphare.Domain.Common;
using EduSphare.Domain.Courses.Modules.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Courses.Modules.Lessons.ValueObjects
{
    public sealed class LessonTitle : ValueObject
    {
        public string Value { get; }

        private LessonTitle(string value)
        {
            Value = value;
        }

        public static LessonTitle Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Lesson title cannot be empty.",
                    nameof(value));
            }

            if (value.Length > 200)
            {
                throw new ArgumentException(
                    "Lesson title cannot exceed 200 characters.",
                    nameof(value));
            }

            return new LessonTitle(value.Trim());
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;
    }
}
