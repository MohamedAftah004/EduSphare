using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Verifications.Exceptions
{
    public sealed class VerificationExpiredException : Exception
    {
        public VerificationExpiredException()
        :base("Verification code has expired")
        {
            
        }
    }
}
