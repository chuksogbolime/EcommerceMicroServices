using System;
using EcommerceMicroServices.Api.Checkout.Command;
using FluentValidation;

namespace EcommerceMicroServices.Api.Checkout.Validators
{
    public class CreateCheckoutCommandValidation :AbstractValidator<CreateCheckoutCommand>
    {
        public CreateCheckoutCommandValidation()
        {
            RuleFor(rule => rule.CustomerId).NotEmpty().GreaterThan(0).WithMessage("Customer Id cannot be empty or less than 0");
            RuleFor(rule => rule.OrderId).NotEmpty().GreaterThan(0).WithMessage("Order Id cannot be empty or less than 0");
        }
    }
}
