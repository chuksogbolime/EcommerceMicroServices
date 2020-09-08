using System;
using System.Collections.Generic;
using MediatR;

namespace EcommerceMicroServices.Api.Checkout.Query
{
    public class GetCheckoutByCustomer :IRequest<IEnumerable<Models.CheckoutModel>>
    {
        public int CustomerId { get; private set; }
        public GetCheckoutByCustomer(int customerId)
        {
            this.CustomerId = customerId;
        }
    }
}
