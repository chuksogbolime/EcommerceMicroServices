using System;
using AutoMapper;
using EcommerceMicroServices.Api.Orders.Core.Entities;
using EcommerceMicroServices.Api.Orders.Core.Models;

namespace EcommerceMicroServices.Api.Orders.Common.ObjectMapProfiles
{
    public class OrdersMapProfile :Profile
    {
        public OrdersMapProfile()
        {
            CreateMap<Order, OrderModel>();
            CreateMap<OrderItem, OrderItemModel>();
        }
    }
}
