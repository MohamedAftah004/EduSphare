using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Application.Common;
using MediatR;

namespace EduSphare.Application.Auth.VerifyEmail
{
    public sealed record VerifyEmailCommand(string Email, string Code) : IRequest<Result>;
}
