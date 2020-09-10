using System;
using System.Collections.Generic;

namespace EcommerceMicroServices.Api.Orders.Core.Entities
{
    public class Order
    {
        public Order()
        {
            Items = new HashSet<OrderItem>();
        }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Total { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}
