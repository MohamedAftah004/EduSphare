using EduSphare.Domain.Common;
using EduSphare.Domain.Common.ValueObjects;
using EduSphare.Domain.Courses;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Cart
{
    public sealed class CartItem : AuditableEntity
    {
        private CartItem() { }

        public Guid CartId { get; private set; }

        public Guid CourseId { get; private set; }

        public Money PriceAtAddition { get; private set; }

        public DateTime AddedAt { get; private set; }


        #region Cart Item Behaviors
     
        //create
        public static CartItem Create(
            Guid cartId,
            Guid courseId,
            Money priceAtAddition)
        {
            return new CartItem
            {
                CartId = cartId,
                CourseId = courseId,
                PriceAtAddition = priceAtAddition,
                AddedAt = DateTime.UtcNow
            };
        }

        #endregion


    }
}
