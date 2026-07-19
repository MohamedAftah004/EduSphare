using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using EduSphare.Application.Abstractions.Security;

namespace EduSphare.Infrastructure.Security
{
    public sealed class RefreshTokenHasher : IRefreshTokenHasher
    {
       
        public string Hash(string refreshToken)
        {
            var bytes = SHA256.HashData(
                Encoding.UTF8.GetBytes(refreshToken)
            );

            return Convert.ToHexString(bytes);
        }

        public bool Verify(string refreshToken, string refreshTokenHash)
        {

            return Hash(refreshToken) == refreshTokenHash;

        }
    }
}
