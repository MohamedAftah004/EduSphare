using EduSphare.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common.ValueObjects;
using EduSphare.Domain.Courses.Modules.Lessons.ValueObjects;

namespace EduSphare.Domain.Courses.Modules.Lessons
{
    public sealed class Lesson : AuditableEntity
    {
       private Lesson(){}

       public Guid ModuleId { get; private set; }
       public LessonTitle Title { get; private set; }
       public int OrderNumber { get; private set; }
       public string? LessonDescription { get; private set; }
       public string? Summary { get; private set; }
       public LessonType LessonType { get; private set; }
       public ContentUrl ContentUrl { get; private set; }
       public Duration? Duration { get; private set; }



        #region Lesson Behaviors

        //create lesson
        public static Lesson Create(
            Guid moduleId,
            LessonTitle title,
            int orderNumber,
            string? lessonDescription,
            string? summary,
            LessonType lessonType,
            ContentUrl contentUrl,
            Duration? duration)
        {
            return new Lesson
            {
                ModuleId = moduleId,
                Title = title,
                OrderNumber = orderNumber,
                LessonDescription = lessonDescription,
                Summary = summary,
                LessonType = lessonType,
                ContentUrl = contentUrl,
                Duration = duration
            };
        }

        //update lesson details
        public void UpdateDetails(
            LessonTitle title,
            int orderNumber,
            string? lessonDescription,
            string? summary,
            LessonType lessonType,
            ContentUrl contentUrl,
            Duration? duration)
        {
            Title = title;
            OrderNumber = orderNumber;
            LessonDescription = lessonDescription;
            Summary = summary;
            LessonType = lessonType;
            ContentUrl = contentUrl;
            Duration = duration;
            SetUpdated();
        }


        //change contentUrl
        public void ChangeContentUrl(ContentUrl contentUrl)
        {
            ContentUrl = contentUrl;
            SetUpdated();
        }

        //change lesson type
        public void ChangeLessonType(LessonType type)
        {
            LessonType = type;
            SetUpdated();
        }

        //change order
        public void ChangeOrder(int orderNumber)
        {
            OrderNumber = orderNumber;
            SetUpdated();
        }

        //change duration
        public void ChangeDuration(Duration? duration)
        {
            Duration = duration;
            SetUpdated();
        }

        #endregion
    }
}
