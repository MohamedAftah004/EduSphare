using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Order.ValueObjects
{
    public enum OrderStatus
    {
        Pending = 1,
        Paid = 2,
        Completed = 3,
        Cancelled = 4
    }
}
