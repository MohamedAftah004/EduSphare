using EduSphare.Domain.Quizs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Quizzes
{
    public interface IQuizRepository
    {
        Task<Quiz?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task<Quiz?> GetByLessonIdAsync(
            Guid lessonId,
            CancellationToken cancellationToken = default);

        Task AddAsync(
            Quiz quiz,
            CancellationToken cancellationToken = default);

        Task UpdateAsync(
            Quiz quiz,
            CancellationToken cancellationToken = default);

        Task DeleteAsync(
            Quiz quiz,
            CancellationToken cancellationToken = default);
    }
}
