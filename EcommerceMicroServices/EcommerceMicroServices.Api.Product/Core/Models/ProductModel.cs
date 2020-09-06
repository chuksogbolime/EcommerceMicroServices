using System;
namespace EcommerceMicroServices.Api.product.Core.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long Inventory { get; set; }
    }
}
