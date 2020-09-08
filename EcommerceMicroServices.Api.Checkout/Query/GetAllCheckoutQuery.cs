using System;
using System.Collections.Generic;
using EcommerceMicroServices.Api.Checkout.Models;
using MediatR;

namespace EcommerceMicroServices.Api.Checkout.Query
{
    public class GetAllCheckoutQuery : IRequest<IEnumerable<CheckoutModel>>
    {
       
    }
}
