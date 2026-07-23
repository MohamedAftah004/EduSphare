using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using FluentValidation;

namespace EduSphare.Application.Auth.Logout
{
    public sealed class LogoutValidator : AbstractValidator<LogoutCommand>
    {
        public LogoutValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty().MinimumLength(10);
        }
    }
}
