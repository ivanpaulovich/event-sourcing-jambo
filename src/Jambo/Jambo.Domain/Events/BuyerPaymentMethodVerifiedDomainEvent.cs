using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Jambo.Domain.AggregatesModel.BuyerAggregate;

namespace Jambo.Domain.Events
{
    public class BuyerAndPaymentMethodVerifiedDomainEvent
        : IRequest
    {
        public Buyer Buyer { get; private set; }
        public PaymentMethod Payment { get; private set; }
        public int OrderId { get; private set; }

        public BuyerAndPaymentMethodVerifiedDomainEvent(Buyer buyer, PaymentMethod payment, int orderId)
        {
            Buyer = buyer;
            Payment = payment;
            OrderId = orderId;
        }
    }
}
