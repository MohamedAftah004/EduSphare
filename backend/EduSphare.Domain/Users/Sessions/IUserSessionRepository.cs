using EduSphare.Domain.Users.Sessions.VO;

namespace EduSphare.Domain.Users.Sessions
{
    public interface IUserSessionRepository
    {
        Task<UserSession?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task<UserSession?> GetByRefreshTokenAsync(
            RefreshToken refreshToken,
            CancellationToken cancellationToken = default);

        Task<List<UserSession>> GetByUserIdAsync(
            Guid userId,
            CancellationToken cancellationToken = default);

        Task AddAsync(
            UserSession session,
            CancellationToken cancellationToken = default);

        void Update(UserSession session);

        void Remove(UserSession session);
    }
}
