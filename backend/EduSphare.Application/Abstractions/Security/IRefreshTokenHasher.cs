using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Application.Abstractions.Security
{
    public interface IRefreshTokenHasher
    { 
        string Hash(string refreshToken);
        bool Verify(string refreshToken, string refreshTokenHash);
    }
}
