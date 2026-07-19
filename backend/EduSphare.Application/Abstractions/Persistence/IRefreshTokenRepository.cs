using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Users.Sessions.ValueObjects;

namespace EduSphare.Application.Abstractions.Persistence
{
    public interface IRefreshTokenRepository
    {
        Task AddAsync(RefreshTokenHash refreshTokenHash, CancellationToken cancellationToken = default);
        Task<RefreshTokenHash> GetByTokenHashAsync(string tokenHash, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<RefreshTokenHash>> GetActiveByUserIdAsync(
            Guid userId,
            CancellationToken cancellationToken = default);

        void Update(RefreshTokenHash refreshTokenHash);

    }
}
