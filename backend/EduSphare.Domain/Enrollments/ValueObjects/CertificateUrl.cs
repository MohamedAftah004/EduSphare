using EduSphare.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Enrollments.ValueObjects
{
    public sealed class CertificateUrl : ValueObject
    {
        private CertificateUrl()
        {
        }

        public string Value { get; }

        private CertificateUrl(string value)
        {
            Value = value;
        }

        public static CertificateUrl Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Certificate url cannot be empty.");
            }

            if (!Uri.TryCreate(
                    value,
                    UriKind.Absolute,
                    out _))
            {
                throw new ArgumentException(
                    "Invalid certificate url.");
            }

            return new CertificateUrl(value.Trim());
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;
    }
}