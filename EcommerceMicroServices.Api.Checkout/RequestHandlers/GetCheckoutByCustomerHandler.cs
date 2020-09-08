using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceMicroServices.Api.Checkout.Data.Interfaces;
using EcommerceMicroServices.Api.Checkout.Models;
using EcommerceMicroServices.Api.Checkout.Query;
using MediatR;

namespace EcommerceMicroServices.Api.Checkout.RequestHandlers
{
    public class GetCheckoutByCustomerHandler : IRequestHandler<GetCheckoutByCustomer, IEnumerable<Models.CheckoutModel>>
    {
        readonly ICheckoutQuery _dbQuery;
        readonly IMapper _mapper;
        public GetCheckoutByCustomerHandler(ICheckoutQuery dbQuery, IMapper mapper)
        {
            _dbQuery = dbQuery;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CheckoutModel>> Handle(GetCheckoutByCustomer request, CancellationToken cancellationToken)
        {
            var result = await _dbQuery.GetByCustomerId(request.CustomerId);
            if (result.IsSuccess)
            {
                return _mapper.Map<IEnumerable<CheckoutModel>>(result.Checkouts);
            }
            return null;
        }
    }
}
