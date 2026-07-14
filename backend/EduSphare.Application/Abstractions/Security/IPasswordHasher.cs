using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Users.ValueObjects;

namespace EduSphare.Application.Abstractions.Security
{
    public interface IPasswordHasher
    {
        PasswordHash Hash(string password);
    }
}
