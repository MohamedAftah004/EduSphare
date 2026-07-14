using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common;

namespace EduSphare.Domain.Users.ValueObjects
{
    public sealed class Email : ValueObject
    {
       public string Value { get; }

       private Email(string value)
       {
           Value = value;
       }

       public static Email Create(string email)
       {
           if(string.IsNullOrEmpty(email))
           {
               throw new ArgumentException("Email cannot be null or empty", nameof(email));
           }
           return new Email(email);
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
