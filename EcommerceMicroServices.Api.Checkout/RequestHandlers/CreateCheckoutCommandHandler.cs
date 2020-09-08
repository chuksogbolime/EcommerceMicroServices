using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceMicroServices.Api.Checkout.Command;
using EcommerceMicroServices.Api.Checkout.Data.Interfaces;
using MediatR;

namespace EcommerceMicroServices.Api.Checkout.RequestHandlers
{
    public class CreateCheckoutCommandHandler : IRequestHandler<CreateCheckoutCommand, (bool IsSuccessful, int CheckoutId)>
    {

        readonly ICheckoutCommand _dbCommand;
        
        public CreateCheckoutCommandHandler(ICheckoutCommand dbCommand)
        {
            _dbCommand = dbCommand;
            
        }

        public async Task<(bool IsSuccessful, int CheckoutId)> Handle(CreateCheckoutCommand request, CancellationToken cancellationToken)
        {
            var checkout = new Models.CheckoutModel
            {
                CustomerId = request.CustomerId,
                HasPaid = request.HasPaid,
                OrderId = request.OrderId
            };

           return await _dbCommand.AddAsync(checkout);
            
        }
    }
}
