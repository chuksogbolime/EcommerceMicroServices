using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMicroServices.Api.Checkout.PipelineBehaviour
{
    public class ValidationBehaviour<TRequest, TResponse> :IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        //where TResponse : IActionResult
        
    {
        readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //pre-processing
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators.Select(o => o.Validate(context)).SelectMany(e => e.Errors).Where(f => f != null)
                .Select(x=>new Models.ValidationErrorModel(x)).ToList();

            if (failures.Any())
            {
                //return new BadRequestResult();
                throw new ValidationException(JsonSerializer.Serialize(failures));
            }

            var result = await next();
            //post-processing

            return result;
        }
    }
}
