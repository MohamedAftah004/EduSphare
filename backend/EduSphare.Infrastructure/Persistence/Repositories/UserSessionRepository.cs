using EduSphare.Domain.Users.Sessions;
using EduSphare.Domain.Users.Sessions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EduSphare.Infrastructure.Persistence.Repositories
{
    public sealed class UserSessionRepository : Application.Auth.IUserSessionRepository
    {
        private readonly AppDbContext _context;

        public UserSessionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserSession?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _context.UserSessions
                .FirstOrDefaultAsync(
                    x => x.Id == id,
                    cancellationToken);
        }

        public async Task<UserSession?> GetByRefreshTokenHashAsync(
            RefreshTokenHash refreshTokenHash,
            CancellationToken cancellationToken = default)
        {
            return await _context.UserSessions
                .FirstOrDefaultAsync(
                    x => x.RefreshTokenHash == refreshTokenHash,
                    cancellationToken);
        }

        public async Task<List<UserSession>> GetByUserIdAsync(
            Guid userId,
            CancellationToken cancellationToken = default)
        {
            return await _context.UserSessions
                .Where(x => x.UserId == userId)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<UserSession>> GetActiveSessionsByUserIdAsync(
            Guid userId,
            CancellationToken cancellationToken = default)
        {
            return await _context.UserSessions
                .Where(x => x.UserId == userId && x.RevokedAt == null && x.ExpiresAt > DateTime.UtcNow)
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(
            UserSession session,
            CancellationToken cancellationToken = default)
        {
            await _context.UserSessions.AddAsync(
                session,
                cancellationToken);
        }

        public void Update(UserSession session)
        {
            _context.UserSessions.Update(session);
        }

        public void Remove(UserSession session)
        {
            _context.UserSessions.Remove(session);
        }
    }
}
