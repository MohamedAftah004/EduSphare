using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Verifications.Exceptions
{
    public sealed class InvalidVerificationCodeException : Exception
    {
        public InvalidVerificationCodeException() : base("Invalid verification code"){}
    }
}
