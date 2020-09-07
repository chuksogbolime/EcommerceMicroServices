using System;
using System.Collections.Generic;

namespace EcommerceMicroServices.Api.Orders.Core.Models
{
    public class OrderModel
    {
        public OrderModel()
        {
            Items = new List<OrderItemModel>();
        }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<OrderItemModel> Items { get; set; }
    }
}
