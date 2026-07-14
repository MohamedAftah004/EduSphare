using EduSphare.Application.Abstractions.Persistence;
using EduSphare.Application.Abstractions.Security;
using EduSphare.Application.Common;
using EduSphare.Domain.Users;
using EduSphare.Domain.Users.ValueObjects;
using MediatR;

namespace EduSphare.Application.Auth.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, Result<Guid>>
    {

        private readonly IUserRepository _userRepo;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUnitOfWork _uow;


        public RegisterHandler(IUserRepository userRepo , IPasswordHasher passwordHasher, IUnitOfWork uow)
        {
            _userRepo = userRepo;
            _passwordHasher = passwordHasher;
            _uow = uow;
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

            await _userRepo.AddAsync(user,cancellationToken);

            await _uow.SaveChangesAsync(cancellationToken);

            return Result.Success(user.Id);
        }
    }
}
