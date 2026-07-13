using EduSphare.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Users.Profiles.VO
{
    public sealed class EmployeeCode : ValueObject
    {
        public string Value { get; }

        private EmployeeCode(string value)
        {
            Value = value;
        }

        public static EmployeeCode Create(string employeeCode)
        {
            if (string.IsNullOrWhiteSpace(employeeCode))
            {
                throw new ArgumentException(
                    "Employee code cannot be empty.",
                    nameof(employeeCode));
            }

            if (employeeCode.Length > 20)
            {
                throw new ArgumentException(
                    "Employee code cannot exceed 20 characters.",
                    nameof(employeeCode));
            }

            return new EmployeeCode(employeeCode.Trim());
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
