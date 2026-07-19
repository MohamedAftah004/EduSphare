using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Application.Common;

namespace EduSphare.Application.Auth.Login
{
    public sealed record LoginCommand(string Email, string Password) : IRequest<Result<LoginResponse>>;
}
