using EduSphare.Domain.Common;

namespace EduSphare.Domain.Enrollments
{
    public sealed class LessonProgress : AuditableEntity
    {
        private LessonProgress() { }

        public Guid StudentId { get; private set; }
        public Guid LessonId { get; private set; }
        public bool IsCompleted { get; private set; }
        public DateTime StartedAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public DateTime? LastViewedAt { get; private set; }


        #region Lesson Progress Behaviors

        public static LessonProgress Create(
            Guid studentId,
            Guid lessonId)
        {
            return new LessonProgress
            {
                StudentId = studentId,
                LessonId = lessonId,
                StartedAt = DateTime.UtcNow
            };
        }

        public void MarkViewed()
        {
            LastViewedAt = DateTime.UtcNow;

            SetUpdated();
        }

        public void Complete()
        {
            if (IsCompleted)
            {
                return;
            }

            IsCompleted = true;
            CompletedAt = DateTime.UtcNow;

            SetUpdated();
        }



        #endregion
    }
}
