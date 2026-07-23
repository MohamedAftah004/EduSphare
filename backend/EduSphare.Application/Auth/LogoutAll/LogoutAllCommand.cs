using EduSphare.Application.Common;
using MediatR;

namespace EduSphare.Application.Auth.LogoutAll;

public sealed record LogoutAllCommand(
    Guid UserId) : IRequest<Result>;