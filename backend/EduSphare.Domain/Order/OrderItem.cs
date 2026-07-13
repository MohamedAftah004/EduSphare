using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common;
using EduSphare.Domain.Common.ValueObjects;

namespace EduSphare.Domain.Order
{
    public sealed class OrderItem : AuditableEntity
    {

        private OrderItem() { }
        public Guid OrderId { get; private set; }
        public Guid CourseId { get; private set; }
        public Money Price { get; private set; }


        #region Order Item Behaviors

        //create order item
        public static OrderItem Create(Guid orderId, Guid courseId, Money price)
        {
            var orderItem = new OrderItem
            {
                OrderId = orderId,
                CourseId = courseId,
                Price = price
            };
            return orderItem;
        }

        #endregion
    }
}
