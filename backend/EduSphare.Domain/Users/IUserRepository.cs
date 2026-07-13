using EduSphare.Domain.Users.VOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Users
{
    public interface IUserRepository
    {


        Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default);
        Task<User?> GetByUserNameAsync(Username username, CancellationToken cancellationToken = default);

        Task<bool> ExistsByEmailAsync(Email email, CancellationToken cancellationToken = default);
        Task<bool> ExistsByUserNameAsync(Username username, CancellationToken cancellationToken = default);

        Task AddAsync(User user, CancellationToken cancellationToken = default);
        void Update(User user);
        void Remove(User user);

    }
}
