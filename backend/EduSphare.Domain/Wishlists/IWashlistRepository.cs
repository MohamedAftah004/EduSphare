using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Wishlists
{
    public interface IWishlistRepository
    {
        Task<Wishlist?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task<Wishlist?> GetByStudentAndCourseAsync(
            Guid studentId,
            Guid courseId,
            CancellationToken cancellationToken = default);

        Task AddAsync(
            Wishlist wishlist,
            CancellationToken cancellationToken = default);

        void Remove(Wishlist wishlist);
    }
}
