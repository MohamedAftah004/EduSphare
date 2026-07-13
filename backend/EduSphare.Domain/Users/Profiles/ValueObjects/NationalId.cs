using EduSphare.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EduSphare.Domain.Users.Profiles.VO
{
    public sealed class NationalId : ValueObject
    {
        public string Value { get; }

        private NationalId(string value)
        {
            Value = value;
        }

        public static NationalId Create(string nationalId)
        {
            if (string.IsNullOrWhiteSpace(nationalId))
            {
                throw new ArgumentException(
                    "National ID cannot be empty.",
                    nameof(nationalId));
            }

            nationalId = nationalId.Trim();

            if (!Regex.IsMatch(nationalId, @"^\d{14}$"))
            {
                throw new ArgumentException(
                    "National ID must contain exactly 14 digits.",
                    nameof(nationalId));
            }

            return new NationalId(nationalId);
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
