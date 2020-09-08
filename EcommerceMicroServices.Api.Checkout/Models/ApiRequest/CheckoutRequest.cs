using System;
namespace EcommerceMicroServices.Api.Checkout.Models.ApiRequest
{
    public class CheckoutRequest
    {
        public int CustomerId { get;  set; }
        public int OrderId { get;  set; }
        public bool HasPaid { get;  set; }
    }
}
