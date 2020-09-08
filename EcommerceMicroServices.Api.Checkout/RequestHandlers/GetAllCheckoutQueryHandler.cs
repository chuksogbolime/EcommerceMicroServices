using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceMicroServices.Api.Checkout.Data.Interfaces;
using EcommerceMicroServices.Api.Checkout.Models;
using EcommerceMicroServices.Api.Checkout.Query;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EcommerceMicroServices.Api.Checkout.RequestHandlers
{
    public class GetAllCheckoutQueryHandler : IRequestHandler<GetAllCheckoutQuery, IEnumerable<CheckoutModel>>
    {
        //readonly ILogger<GetAllCheckoutQueryHandler> _logger;
        readonly ICheckoutQuery _dbQuery;
        readonly IMapper _mapper;
        public GetAllCheckoutQueryHandler(ICheckoutQuery dbQuery, IMapper mapper)
        {
            _dbQuery = dbQuery;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CheckoutModel>> Handle(GetAllCheckoutQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbQuery.GetAllAsync();
            if (result.IsSuccess)
            {
                return _mapper.Map<IEnumerable<CheckoutModel>>(result.Checkouts);
            }
            return null;
        }
    }
}
