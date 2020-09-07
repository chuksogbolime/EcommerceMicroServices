using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceMicroServices.Api.Customer.Core.Models;

namespace EcommerceMicroServices.Api.Customer.Core.Interfaces
{
    public interface ICustomerCommand
    {
        void SeedData();
    }
}
