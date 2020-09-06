using System;
namespace EcommerceMicroServices.Api.product.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long Inventory { get; set; }
    }
}
