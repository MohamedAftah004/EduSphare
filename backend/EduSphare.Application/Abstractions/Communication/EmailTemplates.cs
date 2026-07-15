using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Application.Abstractions.Communication
{
    public static class EmailTemplates
    {
        public static (string Subject, string Body) VerificationCode(string code)
        {
            return (
                "Verify your EduSphare account",
                $"""
                 Welcome to EduSphare!

                 Your verification code is:

                 {code}

                 This code will expire in 10 minutes.
                 """
            );
        }
    }
}
