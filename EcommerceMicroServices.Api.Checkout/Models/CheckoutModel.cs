using System;
namespace EcommerceMicroServices.Api.Checkout.Models
{
    public class CheckoutModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public bool HasPaid { get; set; }
    }
}
