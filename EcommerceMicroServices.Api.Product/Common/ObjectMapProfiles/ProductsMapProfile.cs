using System;
using AutoMapper;
using EcommerceMicroServices.Api.product.Core.Entities;
using EcommerceMicroServices.Api.product.Core.Models;

namespace EcommerceMicroServices.Api.product.Common.ObjectMapProfiles
{
    public class ProductsMapProfile :Profile
    {
        public ProductsMapProfile()
        {
            CreateMap<Product, ProductModel>();
        }
    }
}
