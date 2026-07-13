using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common;

namespace EduSphare.Domain.Courses.Categories
{
    public sealed class CourseCategory : BaseEntity
    {
        private CourseCategory() { }


        public Guid CourseId { get; private set; }
        public Guid CategoryId { get; private set; }

        public static CourseCategory Create(
            Guid courseId,
            Guid categoryId)
        {
            return new CourseCategory
            {
                CourseId = courseId,
                CategoryId = categoryId
            };
        }


    }
}
