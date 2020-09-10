using System;
using System.Collections.Generic;

namespace EcommerceMicroService.Api.Search.Core.Models
{
    public class Customer
    {
        public Customer()
        {
            Orders = new List<Order>();
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
