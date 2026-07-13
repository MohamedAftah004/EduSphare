using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common;
using EduSphare.Domain.Common.ValueObjects;
using EduSphare.Domain.Order.ValueObjects;

namespace EduSphare.Domain.Order
{
    public sealed class Order : AggregateRoot
    {
        private Order() { }

        public int OrderNumber { get; private set; }
        public Guid StudentId { get; private set; }
        public OrderStatus Status { get; private set; }
        public Money TotalAmount { get; private set; }


        private readonly List<OrderItem> _items = [];

        public IReadOnlyCollection<OrderItem> Items
            => _items.AsReadOnly();


        #region Order Behaviors

        public static Order Create(
            int orderNumber,
            Guid studentId)
        {
            return new Order
            {
                OrderNumber = orderNumber,
                StudentId = studentId,
                Status = OrderStatus.Pending,
                TotalAmount = Money.Zero()
            };
        }


        public void MarkAsPaid()
        {
            if (Status != OrderStatus.Pending)
            {
                throw new InvalidOperationException(
                    "Only pending orders can be paid.");
            }

            Status = OrderStatus.Paid;

            SetUpdated();
        }


        public void Cancel()
        {
            if (Status == OrderStatus.Completed)
            {
                throw new InvalidOperationException(
                    "Completed order cannot be cancelled.");
            }

            Status = OrderStatus.Cancelled;

            SetUpdated();
        }

        public void Complete()
        {
            if (Status != OrderStatus.Paid)
            {
                throw new InvalidOperationException(
                    "Only paid orders can be completed.");
            }

            Status = OrderStatus.Completed;

            SetUpdated();
        }

        private void RecalculateTotal()
        {
            decimal total = _items.Sum(x => x.Price.Amount);
            TotalAmount = Money.Create(total);
        }


        #endregion



        #region Order Items Behaviors

        public void AddItem(
            Guid courseId,
            Money price)
        {
            if (_items.Any(x => x.CourseId == courseId))
            {
                throw new InvalidOperationException(
                    "Course already exists in order.");
            }

            _items.Add(
                OrderItem.Create(
                    Id,
                    courseId,
                    price));

            RecalculateTotal();

            SetUpdated();
        }


        public void RemoveItem(Guid courseId)
        {
            var item = _items.FirstOrDefault(
                x => x.CourseId == courseId);

            if (item is null)
            {
                throw new InvalidOperationException(
                    "Order item not found.");
            }

            _items.Remove(item);

            RecalculateTotal();

            SetUpdated();
        }

        #endregion


    }
}
