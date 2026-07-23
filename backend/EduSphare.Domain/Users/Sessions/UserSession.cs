using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common;
using EduSphare.Domain.Users.Sessions.ValueObjects;

namespace EduSphare.Domain.Users.Sessions
{
    public sealed class UserSession : AuditableEntity
    {
        private UserSession(){ }

        //user session id already implemented by auditable entity
        public Guid UserId { get; private set; }
        public RefreshTokenHash RefreshTokenHash { get; private set; }
        public string? DeviceName { get; private set; }
        public string IpAddress { get; private set; }
        public string? UserAgent { get; private set; }

        public DateTime ExpiresAt { get; private set; }

        public DateTime? RevokedAt { get; private set; }

        public DateTime LastActivityAt { get; private set; }

        public bool IsExpired
            => DateTime.UtcNow >= ExpiresAt;

        public bool IsRevoked
            => RevokedAt is not null;

        public bool IsActive
            => !IsExpired && !IsRevoked;


        #region Behaviors

        //create a new user session
        public static UserSession Create(Guid userId,
            RefreshTokenHash refreshTokenHash,
            string deviceName,
            string ipAddress,
            string userAgent,
            DateTime expiresAt)
        {
            return new UserSession
            {
                UserId = userId,
                RefreshTokenHash = refreshTokenHash,
                DeviceName = deviceName,
                IpAddress = ipAddress,
                UserAgent = userAgent,
                ExpiresAt = expiresAt,
                LastActivityAt = DateTime.UtcNow
            };
        }


        //revoke
        public void Revoke()
        {
            if (RevokedAt is not null)
                return;

            RevokedAt = DateTime.UtcNow;
            SetUpdated();
        }


        //update last activity
        public void UpdateLastActivity()
        {
            LastActivityAt = DateTime.UtcNow;
            SetUpdated();   
        }

        //rotate refresh token
        public void RotateRefreshToken(RefreshTokenHash newRefreshTokenHash, DateTime expiresAt)
        {
            ArgumentNullException.ThrowIfNull(newRefreshTokenHash);

            if (expiresAt <= DateTime.UtcNow)
                throw new InvalidOperationException();

            RefreshTokenHash = newRefreshTokenHash;
            ExpiresAt = expiresAt;
            LastActivityAt = DateTime.UtcNow;

            SetUpdated();
        }


        #endregion

    }
}
