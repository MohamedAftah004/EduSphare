using EduSphare.Application.Abstractions.Persistence;
using EduSphare.Application.Abstractions.Security;
using EduSphare.Application.Common;
using EduSphare.Domain.Users;
using EduSphare.Domain.Users.Sessions;
using EduSphare.Domain.Users.Sessions.ValueObjects;
using MediatR;

namespace EduSphare.Application.Auth.RefreshToken;

public sealed class RefreshTokenHandler
    : IRequestHandler<RefreshTokenCommand, Result<RefreshTokenResponse>>
{
    private readonly IUserSessionRepository _userSessionRepository;
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenHasher _refreshTokenHasher;
    private readonly IRefreshTokenGenerator _refreshTokenGenerator;
    private readonly IJwtProvider _jwtProvider;
    private readonly IUnitOfWork _unitOfWork;

    public RefreshTokenHandler(
        IUserSessionRepository userSessionRepository,
        IUserRepository userRepository,
        IRefreshTokenHasher refreshTokenHasher,
        IRefreshTokenGenerator refreshTokenGenerator,
        IJwtProvider jwtProvider,
        IUnitOfWork unitOfWork)
    {
        _userSessionRepository = userSessionRepository;
        _userRepository = userRepository;
        _refreshTokenHasher = refreshTokenHasher;
        _refreshTokenGenerator = refreshTokenGenerator;
        _jwtProvider = jwtProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<RefreshTokenResponse>> Handle(
        RefreshTokenCommand request,
        CancellationToken cancellationToken)
    {
        // Hash incoming refresh token
        var refreshTokenHash = RefreshTokenHash.Create(_refreshTokenHasher.Hash(request.RefreshToken));

        // Find session
        var session = await _userSessionRepository.GetByRefreshTokenHashAsync(
            refreshTokenHash,
            cancellationToken);

        if (session is null)
        {
            return Result.Failure<RefreshTokenResponse>(
                SessionErrors.InvalidRefreshToken);
        }

        if (session.IsRevoked)
        {
            return Result.Failure<RefreshTokenResponse>(
                SessionErrors.Revoked);
        }

        if (session.IsExpired)
        {
            return Result.Failure<RefreshTokenResponse>(
                SessionErrors.RefreshTokenExpired);
        }

        // Get user
        var user = await _userRepository.GetByIdAsync(
            session.UserId,
            cancellationToken);

        if (user is null)
        {
            return Result.Failure<RefreshTokenResponse>(
                UserErrors.UserNotFound);
        }

        // Generate new access token
        var accessToken = _jwtProvider.Generate(user, session.Id);

        // Generate new refresh token
        var newRefreshToken =
            _refreshTokenGenerator.Generate();

        var newRefreshTokenHash = RefreshTokenHash.Create(_refreshTokenHasher.Hash(newRefreshToken));

        // Rotate refresh token
        session.RotateRefreshToken(
            newRefreshTokenHash,
            DateTime.UtcNow.AddDays(7));

        _userSessionRepository.Update(session);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(
            new RefreshTokenResponse(
                accessToken,
                newRefreshToken));
    }
}