﻿using System;
namespace EcommerceMicroServices.Api.Orders.Core.Models
{
    public class OrderItemModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
