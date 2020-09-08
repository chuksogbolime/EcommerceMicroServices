using System;
using MediatR;

namespace EcommerceMicroServices.Api.Checkout.Command
{
    public class CreateCheckoutCommand : IRequest<(bool IsSuccessful, int CheckoutId)>
    {
        public int CustomerId { get; private set; }
        public int OrderId { get; private set; }
        public bool HasPaid { get; private set; }

        public CreateCheckoutCommand(int customerId, int orderId, bool hasPaid)
        {
            this.CustomerId = customerId;
            this.OrderId = orderId;
            this.HasPaid = hasPaid;
        }
    }
}
