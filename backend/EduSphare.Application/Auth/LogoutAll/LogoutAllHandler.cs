using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Application.Abstractions.Persistence;
using EduSphare.Application.Common;
using EduSphare.Domain.Users;
using MediatR;

namespace EduSphare.Application.Auth.LogoutAll
{
    public sealed class LogoutAllHandler : IRequestHandler<LogoutAllCommand, Result>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserSessionRepository _sessionRepository;
        private readonly IUnitOfWork _unitOfWork;


        public LogoutAllHandler(
            IUserRepository userRepository,
            IUserSessionRepository sessionRepository,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _sessionRepository = sessionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(LogoutAllCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(
                request.UserId,
                cancellationToken);

            if (user is null)
                return Result.Failure(UserErrors.UserNotFound);

            var sessions = await _sessionRepository.GetActiveSessionsByUserIdAsync(
                request.UserId,
                cancellationToken);
            foreach (var session in sessions)
            {
                session.Revoke();
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
