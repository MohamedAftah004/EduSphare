using EduSphare.Application.Abstractions.Persistence;
using EduSphare.Application.Abstractions.Security;
using EduSphare.Application.Common;
using EduSphare.Domain.Users;
using EduSphare.Domain.Users.ValueObjects;
using EduSphare.Domain.Verifications;
using EduSphare.Domain.Verifications.Exceptions;
using MediatR;

namespace EduSphare.Application.Auth.VerifyEmail;

public sealed class VerifyEmailHandler
    : IRequestHandler<VerifyEmailCommand, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly IVerificationRepository _verificationRepository;
    private readonly IVerificationCodeHasher _verificationCodeHasher;
    private readonly IUnitOfWork _unitOfWork;

    public VerifyEmailHandler(
        IUserRepository userRepository,
        IVerificationRepository verificationRepository,
        IVerificationCodeHasher verificationCodeHasher,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _verificationRepository = verificationRepository;
        _verificationCodeHasher = verificationCodeHasher;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        VerifyEmailCommand request,
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
            VerificationPurpose.EmailVerification,
            cancellationToken);

        if (verification is null)
            return Result.Failure(VerificationErrors.NotFound);

        var codeHash = _verificationCodeHasher.Hash(request.Code);

        try
        {
            verification.Verify(codeHash);
            user.ActivateEmail();

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