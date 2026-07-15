using EduSphare.Application.Abstractions.Communication;
using EduSphare.Application.Abstractions.Persistence;
using EduSphare.Application.Abstractions.Security;
using EduSphare.Application.Common;
using EduSphare.Domain.Users;
using EduSphare.Domain.Users.ValueObjects;
using EduSphare.Domain.Verifications;
using MediatR;

namespace EduSphare.Application.Auth.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, Result<Guid>>
    {

        private readonly IUserRepository _userRepo;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUnitOfWork _uow;
        private readonly IVerificationRepository _verificationRepository;
        private readonly IVerificationCodeGenerator _verificationCodeGenerator;
        private readonly IVerificationCodeHasher _verificationCodeHasher;
        private readonly IEmailSender _emailSender;

        public RegisterHandler(IUserRepository userRepo, IPasswordHasher passwordHasher, IUnitOfWork uow, IVerificationRepository verificationRepository, IVerificationCodeGenerator verificationCodeGenerator, IVerificationCodeHasher verificationCodeHasher, IEmailSender emailSender)
        {
            _userRepo = userRepo;
            _passwordHasher = passwordHasher;
            _uow = uow;
            _verificationRepository = verificationRepository;
            _verificationCodeGenerator = verificationCodeGenerator;
            _verificationCodeHasher = verificationCodeHasher;
            _emailSender = emailSender;
        }

        public async Task<Result<Guid>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {

            var email = Email.Create(request.Email);
            var username = Username.Create(request.Username);

            var existingUserByEmail = await _userRepo.GetByEmailAsync(email , cancellationToken);
            if (existingUserByEmail is not null)
            {
                return Result.Failure<Guid>(UserErrors.EmailAlreadyInUse);
            }

            var existByUsername = await _userRepo.GetByUsernameAsync(username, cancellationToken);
            if (existByUsername is not null)
            {
                return Result.Failure<Guid>(UserErrors.UsernameAlreadyInUse);
            }


            var passwordHash = _passwordHasher.Hash(request.Password);


            var user = User.Create(
                Name.Create(request.FirstName),
                Name.Create(request.LastName),
                username,
                email,
                passwordHash,
                UserRole.Student);

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

            await _userRepo.AddAsync(user,cancellationToken);

            await _uow.SaveChangesAsync(cancellationToken);

            var (subject, body) = EmailTemplates.VerificationCode(code);

            await _emailSender.SendAsync(
                user.Email.Value,
                subject,
                body,
                cancellationToken);

            return Result.Success(user.Id);
        }
    }
}
