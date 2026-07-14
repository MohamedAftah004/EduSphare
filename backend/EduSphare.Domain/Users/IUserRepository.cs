using EduSphare.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Users
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task<User?> GetByEmailAsync(
            Email email,
            CancellationToken cancellationToken = default);

        Task<User?> GetByUsernameAsync(
            Username username,
            CancellationToken cancellationToken = default);

        Task AddAsync(
            User user,
            CancellationToken cancellationToken = default);
    }
}
