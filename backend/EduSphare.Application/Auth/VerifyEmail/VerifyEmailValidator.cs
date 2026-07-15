using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace EduSphare.Application.Auth.VerifyEmail
{
    public sealed class VerifyEmailValidator : AbstractValidator<VerifyEmailCommand>
    {
        public VerifyEmailValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Code)
                .NotEmpty()
                .Length(6);
        }
    }
}
