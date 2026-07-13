using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Common
{
    public interface ICurrentUser
    {
        Guid? UserId { get; }
        string? Email { get; }
        string? Username { get; }
        string? Role { get; }
        bool IsAuthenticated { get; }
    }
}
