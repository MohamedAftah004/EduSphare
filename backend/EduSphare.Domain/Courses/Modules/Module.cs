using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common;
using EduSphare.Domain.Courses.Modules.Lessons;
using EduSphare.Domain.Courses.Modules.ValueObjects;

namespace EduSphare.Domain.Courses.Modules
{
    public sealed class Module : AuditableEntity
    {
        private Module() { }

       public Guid CourseId { get; private set; }
       public ModuleTitle Title { get; private set; }

       private readonly List<Lesson> _lessons = [];
       public IReadOnlyCollection<Lesson> Lessons => _lessons.AsReadOnly();


       //create module
       public static Module Create(
           Guid courseId,
           ModuleTitle title)
       {
           return new Module
           {
               CourseId = courseId,
               Title = title
           };
       }


        //rename
        public void Rename(ModuleTitle title)
        {
            Title = title;

            SetUpdated();
        }




        #region Lesson Behaviors
        public void AddLesson(Lesson lesson)
        {
            if (_lessons.Any(x => x.Id == lesson.Id))
            {
                throw new InvalidOperationException(
                    "Lesson already exists.");
            }

            _lessons.Add(lesson);

            SetUpdated();
        }

        public void RemoveLesson(Guid lessonId)
        {
            var lesson = _lessons.FirstOrDefault(x => x.Id == lessonId);

            if (lesson is null)
            {
                throw new InvalidOperationException(
                    "Lesson not found.");
            }

            _lessons.Remove(lesson);

            SetUpdated();
        }

        public void ReorderLesson(Guid lessonId, int orderNumber)
        {
            var lesson = _lessons.FirstOrDefault(x => x.Id == lessonId);

            if (lesson is null)
            {
                throw new InvalidOperationException("Lesson not found.");
            }

            lesson.ChangeOrder(orderNumber);

            SetUpdated();
        }


        #endregion


    }
}
