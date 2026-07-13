using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Courses
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    namespace EduSphare.Domain.Courses
    {
        public interface ICourseRepository
        {
            Task<Course?> GetByIdAsync(
                Guid id,
                CancellationToken cancellationToken = default);

            Task AddAsync(
                Course course,
                CancellationToken cancellationToken = default);

            Task UpdateAsync(
                Course course,
                CancellationToken cancellationToken = default);

            Task DeleteAsync(
                Course course,
                CancellationToken cancellationToken = default);
        }
    }
}
