using EduSphare.Domain.Common;

namespace EduSphare.Domain.Enrollments
{
    public sealed class Enrollment : AggregateRoot
    {
        private Enrollment() { }


        public Guid CourseId { get; private set; }
        public Guid StudentId { get; private set; }
        public DateTime EnrolledAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }

        public readonly List<LessonProgress> _progress = [];
        public IReadOnlyCollection<LessonProgress> Progress => _progress.AsReadOnly();  

        public Certificate? Certificate { get; private set; }


        #region Enrollment Behaviors

        // enroll
        public static Enrollment Create(
            Guid studentId,
            Guid courseId)
        {
            return new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrolledAt = DateTime.UtcNow
            };
        }

        public void AddLessonProgress(
            LessonProgress progress)
        {
            if (_progress.Any(x => x.LessonId == progress.LessonId))
            {
                throw new InvalidOperationException(
                    "Lesson progress already exists.");
            }

            _progress.Add(progress);

            SetUpdated();
        }


        public void CompleteCourse()
        {
            if (_progress.Any(x => !x.IsCompleted))
            {
                throw new InvalidOperationException(
                    "All lessons must be completed.");
            }

            CompletedAt = DateTime.UtcNow;

            SetUpdated();
        }


        public void IssueCertificate(
            Certificate certificate)
        {
            if (Certificate is not null)
            {
                throw new InvalidOperationException(
                    "Certificate already issued.");
            }

            if (CompletedAt is null)
            {
                throw new InvalidOperationException(
                    "Course is not completed.");
            }

            Certificate = certificate;

            SetUpdated();
        }
        #endregion
    }
}
