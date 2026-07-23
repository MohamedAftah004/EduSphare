using EduSphare.Application.Common;
using MediatR;

namespace EduSphare.Application.Auth.ResetPassword;

public sealed record ResetPasswordCommand(
    string Email,
    string Code,
    string NewPassword) : IRequest<Result>;
