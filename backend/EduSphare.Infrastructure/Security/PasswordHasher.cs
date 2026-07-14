using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Application.Abstractions.Security;
using EduSphare.Domain.Users;
using EduSphare.Domain.Users.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace EduSphare.Infrastructure.Security
{
    public sealed class PasswordHasher : IPasswordHasher
    {

        private readonly PasswordHasher<object> _hasher = new();


        public PasswordHash Hash(string password)
        {

            var hash = _hasher.HashPassword(null!, password);
            return PasswordHash.Create(hash);

        }
    }
}
