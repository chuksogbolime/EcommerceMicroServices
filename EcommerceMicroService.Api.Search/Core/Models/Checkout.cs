using System;
namespace EcommerceMicroService.Api.Search.Core.Models
{
    public class Checkout
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public bool HasPaid { get; set; }
    }
}
