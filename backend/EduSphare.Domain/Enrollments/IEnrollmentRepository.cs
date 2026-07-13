using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Enrollments
{
    public interface IEnrollmentRepository
    {
        Task<Enrollment?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task<Enrollment?> GetByStudentAndCourseAsync(
            Guid studentId,
            Guid courseId,
            CancellationToken cancellationToken = default);

        Task AddAsync(
            Enrollment enrollment,
            CancellationToken cancellationToken = default);

        void Update(Enrollment enrollment);

        void Delete(Enrollment enrollment);
    }
}
