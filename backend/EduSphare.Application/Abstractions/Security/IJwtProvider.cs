using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Users;

namespace EduSphare.Application.Abstractions.Security
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}
