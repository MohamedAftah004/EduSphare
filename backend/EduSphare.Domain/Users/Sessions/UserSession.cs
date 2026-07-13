using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common;
using EduSphare.Domain.Users.Sessions.VO;

namespace EduSphare.Domain.Users.Sessions
{
    public sealed class UserSession : AuditableEntity
    {
        private UserSession(){ }

        //user session id already implemented by auditable entity
        public Guid UserId { get; private set; }
        public RefreshToken RefreshToken { get; private set; }
        public string DeviceName { get; private set; }
        public string IpAddress { get; private set; }
        public string UserAgent { get; private set; }

        public DateTime ExpiresAt { get; private set; }

        public DateTime? RevokedAt { get; private set; }

        public DateTime LastActivityAt { get; private set; }



        #region Behaviors

        //create a new user session
        public static UserSession Create(Guid userId,
            RefreshToken refreshToken,
            string deviceName,
            string ipAddress,
            string userAgent,
            DateTime expiresAt)
        {
            return new UserSession
            {
                UserId = userId,
                RefreshToken = refreshToken,
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
            {
                throw new InvalidOperationException("Session is already revoked.");
            }

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
        public void RotateRefreshToken(RefreshToken newRefreshToken, DateTime expiresAt)
        {
            RefreshToken = newRefreshToken;
            ExpiresAt = expiresAt;
            LastActivityAt = DateTime.UtcNow;

            SetUpdated();
        }



        #region Helpers Functions

        public bool IsExpired()
        {
            return DateTime.UtcNow > ExpiresAt;
        }

        public bool IsRevoked()
        {
            return RevokedAt.HasValue;
        }

        public bool IsActive()
        {
            return !IsExpired() && !IsRevoked();
        }

        #endregion

        #endregion

    }
}
