using EduSphare.Application.Common;
using MediatR;

namespace EduSphare.Application.Auth.RefreshToken;

public sealed record RefreshTokenCommand(
    string RefreshToken)
    : IRequest<Result<RefreshTokenResponse>>;