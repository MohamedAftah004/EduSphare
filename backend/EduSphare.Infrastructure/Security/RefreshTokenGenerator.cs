using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using EduSphare.Application.Abstractions.Security;

namespace EduSphare.Infrastructure.Security
{
    public sealed class RefreshTokenGenerator : IRefreshTokenGenerator
    {
        private const int TokenSize = 64;
        public string Generate()
        {
            var bytes = RandomNumberGenerator.GetBytes(TokenSize);
            return Convert.ToBase64String(bytes);
        }
    }
}
