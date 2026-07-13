using EduSphare.Domain.Common;
using EduSphare.Domain.Courses.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Courses.Modules.ValueObjects
{
    public sealed class ModuleTitle : ValueObject
    {
        public string Value { get; }

        private ModuleTitle(string value)
        {
            Value = value;
        }

        public static ModuleTitle Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Module title cannot be empty.",
                    nameof(value));
            }

            if (value.Length > 200)
            {
                throw new ArgumentException(
                    "Module title cannot exceed 200 characters.",
                    nameof(value));
            }

            return new ModuleTitle(value.Trim());
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;
    }
}


