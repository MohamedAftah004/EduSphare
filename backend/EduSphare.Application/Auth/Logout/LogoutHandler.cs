using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Application.Abstractions.Persistence;
using EduSphare.Application.Abstractions.Security;
using EduSphare.Application.Common;
using EduSphare.Domain.Users.Sessions.ValueObjects;
using MediatR;

namespace EduSphare.Application.Auth.Logout
{
    public sealed class LogoutHandler : IRequestHandler<LogoutCommand, Result>
    {
        private readonly IUserSessionRepository _userSessionRepository;
        private readonly IRefreshTokenHasher _refreshTokenHasher;
        private readonly IUnitOfWork _uow;

        public LogoutHandler(IUserSessionRepository userSessionRepository, IRefreshTokenHasher refreshTokenHasher, IUnitOfWork uow)
        {
            _userSessionRepository = userSessionRepository;
            _refreshTokenHasher = refreshTokenHasher;
            _uow = uow;
        }

        public async Task<Result> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var refreshTokenHash = RefreshTokenHash.Create(request.RefreshToken);
            var session = await _userSessionRepository.GetByRefreshTokenHashAsync(refreshTokenHash, cancellationToken);

            if (session == null)
                return Result.Success();

            session.Revoke();

            await _uow.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
