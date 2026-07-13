using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Reviews
{
    public interface ICourseReviewRepository
    {
        Task<CourseReview?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task<CourseReview?> GetByStudentAndCourseAsync(
            Guid studentId,
            Guid courseId,
            CancellationToken cancellationToken = default);

        Task AddAsync(
            CourseReview review,
            CancellationToken cancellationToken = default);

        void Update(CourseReview review);

        void Remove(CourseReview review);
    }
}
