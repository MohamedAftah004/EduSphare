using EduSphare.Domain.Common;
using EduSphare.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Payment
{
    public sealed class Payment : AggregateRoot
    {
        private Payment() { }

        public Guid OrderId { get; private set; }
        public Money Amount { get; private set; }
        public string? TransactionId { get; private set; }
        public string? ProviderReferenceId { get; private set; }
        public PaymentMethodType PaymentMethod { get; private set; }
        public PaymentStatus Status { get; private set; }
        public string? GatewayResponse { get; private set; }
        public DateTime? PaidAt { get; private set; }


        #region Payment Behaviors

        public static Payment Create(
            Guid orderId,
            Money amount,
            PaymentMethodType paymentMethod)
        {
            return new Payment
            {
                OrderId = orderId,
                Amount = amount,
                PaymentMethod = paymentMethod,
                Status = PaymentStatus.Pending
            };
        }

        public void MarkAsSucceeded(
            string transactionId,
            string providerReferenceId,
            string? gatewayResponse)
        {
            if (Status != PaymentStatus.Pending)
            {
                throw new InvalidOperationException(
                    "Only pending payments can be completed.");
            }

            TransactionId = transactionId;
            ProviderReferenceId = providerReferenceId;
            GatewayResponse = gatewayResponse;

            Status = PaymentStatus.Succeeded;
            PaidAt = DateTime.UtcNow;

            SetUpdated();
        }


        public void MarkAsFailed(
            string? gatewayResponse)
        {
            if (Status != PaymentStatus.Pending)
            {
                throw new InvalidOperationException(
                    "Only pending payments can fail.");
            }

            GatewayResponse = gatewayResponse;

            Status = PaymentStatus.Failed;

            SetUpdated();
        }

        public void Refund()
        {
            if (Status != PaymentStatus.Succeeded)
            {
                throw new InvalidOperationException(
                    "Only successful payments can be refunded.");
            }

            Status = PaymentStatus.Refunded;

            SetUpdated();
        }





        #endregion

    }
}
