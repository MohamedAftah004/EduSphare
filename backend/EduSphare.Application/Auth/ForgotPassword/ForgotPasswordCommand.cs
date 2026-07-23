using EduSphare.Application.Common;
using MediatR;

namespace EduSphare.Application.Auth.ForgotPassword;

public sealed record ForgotPasswordCommand(
    string Email) : IRequest<Result>;
