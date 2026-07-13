using EduSphare.Domain.Common;

namespace EduSphare.Domain.Payments;

public static class PaymentErrors
{
    public static readonly Error NotFound =
        new(
            "Payment.NotFound",
            "Payment was not found.");

    public static readonly Error AlreadyPaid =
        new(
            "Payment.AlreadyPaid",
            "Payment has already been completed.");

    public static readonly Error PaymentFailed =
        new(
            "Payment.Failed",
            "Payment process failed.");

    public static readonly Error InvalidStatus =
        new(
            "Payment.InvalidStatus",
            "Payment status is invalid.");

    public static readonly Error InvalidAmount =
        new(
            "Payment.InvalidAmount",
            "Payment amount is invalid.");
}