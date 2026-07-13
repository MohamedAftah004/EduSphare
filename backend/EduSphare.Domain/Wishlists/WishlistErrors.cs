using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common;

namespace EduSphare.Domain.Wishlists
{
    public static class WishlistErrors
    {
        public static readonly Error AlreadyExists =
            new(
                "Wishlist.AlreadyExists",
                "Course already exists in wishlist.");

        public static readonly Error NotFound =
            new(
                "Wishlist.NotFound",
                "Wishlist item was not found.");
    }
}
