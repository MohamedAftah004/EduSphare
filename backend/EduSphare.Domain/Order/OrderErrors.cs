using EduSphare.Domain.Common;

namespace EduSphare.Domain.Orders;

public static class OrderErrors
{
    public static readonly Error NotFound =
        new(
            "Order.NotFound",
            "Order was not found.");

    public static readonly Error ItemNotFound =
        new(
            "Order.ItemNotFound",
            "Order item was not found.");

    public static readonly Error AlreadyPaid =
        new(
            "Order.AlreadyPaid",
            "Order has already been paid.");

    public static readonly Error CannotCancel =
        new(
            "Order.CannotCancel",
            "Order cannot be cancelled.");

    public static readonly Error EmptyOrder =
        new(
            "Order.EmptyOrder",
            "Order must contain at least one item.");
}