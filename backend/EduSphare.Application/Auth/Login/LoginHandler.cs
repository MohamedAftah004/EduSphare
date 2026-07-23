using EduSphare.Application.Abstractions.Communication;
using EduSphare.Application.Abstractions.Persistence;
using EduSphare.Application.Abstractions.Security;
using EduSphare.Application.Common;
using EduSphare.Domain.Users;
using EduSphare.Domain.Users.Sessions;
using EduSphare.Domain.Users.Sessions.ValueObjects;
using EduSphare.Domain.Users.ValueObjects;
using MediatR;

namespace EduSphare.Application.Auth.Login;

public sealed class LoginHandler : IRequestHandler<LoginCommand, Result<LoginResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserSessionRepository _userSessionRepository;
    private readonly IRequestContext _requestContext;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;
    private readonly IRefreshTokenGenerator _refreshTokenGenerator;
    private readonly IRefreshTokenHasher _refreshTokenHasher;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUnitOfWork _unitOfWork;

    public LoginHandler(
        IUserRepository userRepository,
        IUserSessionRepository userSessionRepository,
        IRequestContext requestContext,
        IPasswordHasher passwordHasher,
        IJwtProvider jwtProvider,
        IRefreshTokenGenerator refreshTokenGenerator,
        IRefreshTokenHasher refreshTokenHasher,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _userSessionRepository = userSessionRepository;
        _requestContext = requestContext;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
        _refreshTokenGenerator = refreshTokenGenerator;
        _refreshTokenHasher = refreshTokenHasher;
        _unitOfWork = unitOfWork;

    }

    public async Task<Result<LoginResponse>> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        var email = Email.Create(request.Email);

        var user = await _userRepository.GetByEmailAsync(
            email,
            cancellationToken);

        if (user is null)
        {
            return Result.Failure<LoginResponse>(
                UserErrors.InvalidCredentials);
        }

        if (!_passwordHasher.Verify(request.Password, user.PasswordHash))
        {
            return Result.Failure<LoginResponse>(
                UserErrors.InvalidCredentials);
        }

        if (user.Status == UserStatus.PendingEmailVerification)
        {
            return Result.Failure<LoginResponse>(
                UserErrors.EmailNotVerified);
        }

        var refreshToken = _refreshTokenGenerator.Generate();

        var refreshTokenHash = _refreshTokenHasher.Hash(refreshToken);

        var session = UserSession.Create(
            user.Id,
            RefreshTokenHash.Create(refreshTokenHash),
            _requestContext.UserAgent ?? "Unknown",
            _requestContext.IpAddress ?? "Unknown",
            _requestContext.UserAgent ?? "Unknown",
            DateTime.UtcNow.AddDays(7));

        await _userSessionRepository.AddAsync(
            session,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var accessToken = _jwtProvider.Generate(user, session.Id);

        return Result.Success(
            new LoginResponse(
                accessToken,
                refreshToken,
                session.ExpiresAt));
    }
}