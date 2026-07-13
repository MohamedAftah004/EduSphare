using EduSphare.Domain.Common;

namespace EduSphare.Domain.Carts;

public static class CartErrors
{
    public static readonly Error NotFound =
        new(
            "Cart.NotFound",
            "Cart was not found.");

    public static readonly Error ItemNotFound =
        new(
            "Cart.ItemNotFound",
            "Cart item was not found.");

    public static readonly Error ItemAlreadyExists =
        new(
            "Cart.ItemAlreadyExists",
            "Course already exists in the cart.");

    public static readonly Error EmptyCart =
        new(
            "Cart.EmptyCart",
            "Cart is empty.");
}