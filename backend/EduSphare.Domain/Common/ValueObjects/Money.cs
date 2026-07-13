using EduSphare.Domain.Common;

namespace EduSphare.Domain.Common.ValueObjects;

public sealed class Money : ValueObject
{
    public decimal Amount { get; }

    private Money(decimal amount)
    {
        Amount = amount;
    }

    public static Money Create(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException(
                "Money amount cannot be negative.",
                nameof(amount));
        }

        return new Money(decimal.Round(amount, 2));
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Amount;
    }

    public override string ToString()
    {
        return Amount.ToString("0.00");
    }

    public static Money Zero()
    {
        return new Money(0);
    }
}