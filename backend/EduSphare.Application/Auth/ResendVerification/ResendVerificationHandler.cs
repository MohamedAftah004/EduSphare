using EduSphare.Application.Abstractions.Communication;
using EduSphare.Application.Abstractions.Persistence;
using EduSphare.Application.Abstractions.Security;
using EduSphare.Application.Common;
using EduSphare.Domain.Users;
using EduSphare.Domain.Users.ValueObjects;
using EduSphare.Domain.Verifications;
using MediatR;

namespace EduSphare.Application.Auth.ResendVerification
{
    public sealed class ResendVerificationHandler : IRequestHandler<ResendVerificationCommand, Result>
    {

        private readonly IUserRepository _userRepository;
        private readonly IVerificationRepository _verificationRepository;
        private readonly IVerificationCodeGenerator _verificationCodeGenerator;
        private readonly IVerificationCodeHasher _verificationCodeHasher;
        private readonly IEmailSender _emailSender;
        private readonly IUnitOfWork _unitOfWork;

        public ResendVerificationHandler(IUserRepository userRepository, IVerificationRepository verificationRepository, IVerificationCodeGenerator verificationCodeGenerator, IVerificationCodeHasher verificationCodeHasher, IEmailSender emailSender, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _verificationRepository = verificationRepository;
            _verificationCodeGenerator = verificationCodeGenerator;
            _verificationCodeHasher = verificationCodeHasher;
            _emailSender = emailSender;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(
            ResendVerificationCommand request,
            CancellationToken cancellationToken)
        {
            var email = Email.Create(request.Email);

            var user = await _userRepository.GetByEmailAsync(
                email,
                cancellationToken);

            if (user is null)
                return Result.Failure(UserErrors.UserNotFound);

            if (user.Status == UserStatus.Active)
                return Result.Failure(UserErrors.EmailAlreadyVerified);

            var code = _verificationCodeGenerator.Generate();

            var codeHash = _verificationCodeHasher.Hash(code);

            var verification = Verification.Create(
                user.Id,
                codeHash,
                VerificationPurpose.EmailVerification,
                TimeSpan.FromMinutes(10));

            await _verificationRepository.AddAsync(
                verification,
                cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var (subject, body) = EmailTemplates.VerificationCode(code);

            await _emailSender.SendAsync(
                to: user.Email.Value,
                subject,
                body,
                cancellationToken);

            return Result.Success();
        }
    }
}
