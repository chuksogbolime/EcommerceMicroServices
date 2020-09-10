using System;
using System.Collections.Generic;

namespace EcommerceMicroService.Api.Search.Core.Models
{
    public class Order
    {
        public Order()
        {
            Items = new List<OrderItem>();
            Checkout = new Checkout();
        }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
        public Checkout Checkout { get; set; }
    }
}
