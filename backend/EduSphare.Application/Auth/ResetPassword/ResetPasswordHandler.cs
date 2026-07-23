using EduSphare.Application.Abstractions.Persistence;
using EduSphare.Application.Abstractions.Security;
using EduSphare.Application.Auth;
using EduSphare.Application.Common;
using EduSphare.Domain.Users;
using EduSphare.Domain.Users.ValueObjects;
using EduSphare.Domain.Verifications;
using EduSphare.Domain.Verifications.Exceptions;
using MediatR;

namespace EduSphare.Application.Auth.ResetPassword;

public sealed class ResetPasswordHandler : IRequestHandler<ResetPasswordCommand, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly IVerificationRepository _verificationRepository;
    private readonly IUserSessionRepository _userSessionRepository;
    private readonly IVerificationCodeHasher _verificationCodeHasher;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;

    public ResetPasswordHandler(
        IUserRepository userRepository,
        IVerificationRepository verificationRepository,
        IUserSessionRepository userSessionRepository,
        IVerificationCodeHasher verificationCodeHasher,
        IPasswordHasher passwordHasher,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _verificationRepository = verificationRepository;
        _userSessionRepository = userSessionRepository;
        _verificationCodeHasher = verificationCodeHasher;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        ResetPasswordCommand request,
        CancellationToken cancellationToken)
    {
        var email = Email.Create(request.Email);

        var user = await _userRepository.GetByEmailAsync(
            email,
            cancellationToken);

        if (user is null)
            return Result.Failure(UserErrors.UserNotFound);

        var verification = await _verificationRepository.GetLatestAsync(
            user.Id,
            VerificationPurpose.PasswordReset,
            cancellationToken);

        if (verification is null)
            return Result.Failure(VerificationErrors.NotFound);

        var codeHash = _verificationCodeHasher.Hash(request.Code);

        try
        {
            verification.Verify(codeHash);

            var newPasswordHash = _passwordHasher.Hash(request.NewPassword);
            user.ChangePassword(newPasswordHash);

            // Revoke all active sessions on password reset for security
            var activeSessions = await _userSessionRepository.GetActiveSessionsByUserIdAsync(
                user.Id,
                cancellationToken);

            foreach (var session in activeSessions)
            {
                session.Revoke();
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
        catch (VerificationAlreadyVerifiedException)
        {
            return Result.Failure(VerificationErrors.AlreadyVerified);
        }
        catch (VerificationExpiredException)
        {
            return Result.Failure(VerificationErrors.ExpiredCode);
        }
        catch (InvalidVerificationCodeException)
        {
            return Result.Failure(VerificationErrors.InvalidCode);
        }
    }
}
