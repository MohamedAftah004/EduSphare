using EduSphare.Domain.Users.Sessions;
using EduSphare.Domain.Users.Sessions.ValueObjects;

namespace EduSphare.Application.Auth
{
    public interface IUserSessionRepository
    {
        Task<UserSession?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task<UserSession?> GetByRefreshTokenHashAsync(
            RefreshTokenHash refreshTokenHash,
            CancellationToken cancellationToken = default);

        Task<List<UserSession>> GetByUserIdAsync(
            Guid userId,
            CancellationToken cancellationToken = default);

        Task<List<UserSession>> GetActiveSessionsByUserIdAsync(Guid userId,
            CancellationToken cancellationToken = default);

        Task AddAsync(
            UserSession session,
            CancellationToken cancellationToken = default);

        void Update(UserSession session);

        void Remove(UserSession session);
    }
}
