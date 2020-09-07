using System;
using AutoMapper;
using EcommerceMicroServices.Api.Customer.Core.Models;

namespace EcommerceMicroServices.Api.Customer.Common.ObjectMapProfiles
{
    public class CustomerMapProfile :Profile
    {
        public CustomerMapProfile()
        {
            CreateMap<Core.Entities.Customer, CustomerModel>();
        }
    }
}
