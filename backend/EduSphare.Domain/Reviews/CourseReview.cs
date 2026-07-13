using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common;
using EduSphare.Domain.Reviews.ValueObjects;

namespace EduSphare.Domain.Reviews
{
    public sealed class CourseReview : AggregateRoot
    {
       private CourseReview(){}

       public Guid StudentId { get; private set; }
       public Guid CourseId { get; private set; }
       public ReviewStars Stars { get; private set; }
       public ReviewText Review { get; private set; }


       #region Behaviors

       public static CourseReview Create(
           Guid studentId,
           Guid courseId,
           ReviewStars stars,
           ReviewText review)
       {
           return new CourseReview
           {
               StudentId = studentId,
               CourseId = courseId,
               Stars = stars,
               Review = review
           };
       }

       public void Update(
           ReviewStars stars,
           ReviewText review)
       {
           Stars = stars;
           Review = review;

           SetUpdated();
       }

       #endregion

    }
}
