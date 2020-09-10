# eCommerce MicroServices
This project shows some simple implementations of a set of microservices. It uses EFCore In-Memory database to hold data and exposes documentations using swagger. It also has a flavour of clean architecture built into it for SOLID. 

The "Api.Checkout" implements the MediatR & CQRS pattern, uses Pipeline Behaviour and FluentValidation for command property validations.

The "Api.Search" project uses IHttpClientFactory to initiate http calls to other services. Polly is added for resilience. 
