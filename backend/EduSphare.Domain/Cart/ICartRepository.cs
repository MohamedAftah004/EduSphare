using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Cart
{
    public interface ICartRepository
    {
        Task<Cart?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task<Cart?> GetByStudentIdAsync(
            Guid studentId,
            CancellationToken cancellationToken = default);

        Task AddAsync(
            Cart cart,
            CancellationToken cancellationToken = default);

        void Update(Cart cart);

        void Remove(Cart cart);
    }
}
