using MediatR;
using System;
using EduSphare.Application.Common;

namespace EduSphare.Application.Auth.ResendVerification
{
    public sealed record ResendVerificationCommand(string Email) : IRequest<Result>;
}
