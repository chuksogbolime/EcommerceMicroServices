using System;
namespace EcommerceMicroServices.Api.Checkout.Data.Entities
{
    public class Checkout
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public bool HasPaid { get; set; }
    }
}
