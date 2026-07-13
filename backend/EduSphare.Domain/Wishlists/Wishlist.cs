using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common;

namespace EduSphare.Domain.Wishlists
{
    public sealed class Wishlist : AggregateRoot
    {
        private Wishlist() { }


        public Guid StudentId { get; private set; }
        public Guid CourseId { get; private set;}


        #region Behaviors

        public static Wishlist Create(
            Guid studentId,
            Guid courseId)
        {
            return new Wishlist
            {
                StudentId = studentId,
                CourseId = courseId
            };
        }

        #endregion
    }
}
