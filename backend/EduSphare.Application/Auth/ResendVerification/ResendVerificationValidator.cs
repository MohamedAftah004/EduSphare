using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace EduSphare.Application.Auth.ResendVerification
{
    public sealed class ResendVerificationValidator : AbstractValidator<ResendVerificationCommand>
    {
        public ResendVerificationValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

        }
    }
}
