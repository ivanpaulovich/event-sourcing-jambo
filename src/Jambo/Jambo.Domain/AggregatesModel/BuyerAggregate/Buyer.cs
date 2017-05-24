using Jambo.Domain.Events;
using Jambo.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jambo.Domain.AggregatesModel.BuyerAggregate
{
    public class Buyer
      : Entity, IAggregateRoot
    {
        public string IdentityGuid { get; private set; }

        private List<PaymentMethod> _paymentMethods;

        public IEnumerable<PaymentMethod> PaymentMethods => _paymentMethods.AsReadOnly();

        protected Buyer()
        {

            _paymentMethods = new List<PaymentMethod>();
        }

        public Buyer(string identity) : this()
        {
            IdentityGuid = !string.IsNullOrWhiteSpace(identity) ? identity : throw new ArgumentNullException(nameof(identity));
        }

        public PaymentMethod VerifyOrAddPaymentMethod(
            int cardTypeId, string alias, string cardNumber,
            string securityNumber, string cardHolderName, DateTime expiration, int orderId)
        {
            var existingPayment = _paymentMethods.Where(p => p.IsEqualTo(cardTypeId, cardNumber, expiration))
                .SingleOrDefault();

            if (existingPayment != null)
            {
                AddDomainEvent(new BuyerAndPaymentMethodVerifiedDomainEvent(this, existingPayment, orderId));

                return existingPayment;
            }
            else
            {
                var payment = new PaymentMethod(cardTypeId, alias, cardNumber, securityNumber, cardHolderName, expiration);

                _paymentMethods.Add(payment);

                AddDomainEvent(new BuyerAndPaymentMethodVerifiedDomainEvent(this, payment, orderId));

                return payment;
            }
        }
    }
}
