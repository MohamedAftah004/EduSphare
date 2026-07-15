using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Verifications.Exceptions
{
    public sealed class VerificationAlreadyVerifiedException : Exception
    {
        public VerificationAlreadyVerifiedException():base("Verification code already used"){}
    }
}
