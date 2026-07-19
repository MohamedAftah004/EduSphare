using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace EduSphare.Application.Auth.Login
{
    public sealed class LoginValidator : AbstractValidator<LoginCommand>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8); ;

        }
    }
}
