using EduSphare.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Enrollments.ValueObjects
{
    public sealed class CertificateNumber : ValueObject
    {
        private CertificateNumber()
        {
        }

        public string Value { get; }

        private CertificateNumber(string value)
        {
            Value = value;
        }

        public static CertificateNumber Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Certificate number cannot be empty.");
            }

            if (value.Length > 100)
            {
                throw new ArgumentException(
                    "Certificate number is too long.");
            }

            return new CertificateNumber(value.Trim());
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;
    }
}
