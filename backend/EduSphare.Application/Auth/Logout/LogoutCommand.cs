using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Application.Common;
using MediatR;

namespace EduSphare.Application.Auth.Logout
{
    public sealed record LogoutCommand(string RefreshToken) : IRequest<Result>;

}
