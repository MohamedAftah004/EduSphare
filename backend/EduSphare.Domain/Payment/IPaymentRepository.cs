using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Payment
{
    public interface IPaymentRepository
    {
        Task<Payment?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task<Payment?> GetByOrderIdAsync(
            Guid orderId,
            CancellationToken cancellationToken = default);

        Task AddAsync(
            Payment payment,
            CancellationToken cancellationToken = default);
    }
}
