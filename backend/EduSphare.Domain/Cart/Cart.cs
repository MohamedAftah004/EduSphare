using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common;
using EduSphare.Domain.Common.ValueObjects;

namespace EduSphare.Domain.Cart
{
    public sealed class Cart : AggregateRoot
    {

        private Cart() { }
        public Guid StudentId { get; private set; }

        private readonly List<CartItem> _items = new();
        public IReadOnlyCollection<CartItem> Items
            => _items.AsReadOnly();
        #region Cart Behaviors
        //create
        public static Cart Create(Guid studentId)
        {
            return new Cart
            {
                StudentId = studentId
            };
        }
        //add item
        public void AddItem(
            Guid courseId,
            Money priceAtAddition)
        {
            if (_items.Any(x => x.CourseId == courseId))
            {
                throw new InvalidOperationException(
                    "Course already exists in cart.");
            }

            _items.Add(
                CartItem.Create(
                    Id,
                    courseId,
                    priceAtAddition));

            SetUpdated();
        }
        //remove item
        public void RemoveItem(Guid itemId)
        {
            var item = _items.FirstOrDefault(x => x.Id == itemId);
            if (item == null)
            {
                throw new InvalidOperationException(
                    "Item does not exist in the cart.");
            }
            _items.Remove(item);
            SetUpdated();
        }

        //clear cart
        public void Clear()
        {
            _items.Clear();

            SetUpdated();
        }

        //totl price
        public decimal GetTotalAmount()
        {
            return _items.Sum(x => x.PriceAtAddition.Amount);
        }


        #endregion



    }
}
