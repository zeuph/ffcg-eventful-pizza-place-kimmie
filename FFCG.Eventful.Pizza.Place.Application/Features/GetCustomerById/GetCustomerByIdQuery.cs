using FFCG.Eventful.Pizza.Place.Application.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using MediatR;

namespace FFCG.Eventful.Pizza.Place.Application.Features.GetCustomerById;

public record GetCustomerByIdQuery(Guid Id) : IRequest<Customer>;

public class GetCustomerByIdHandler(ICustomerProvider _provider) : IRequestHandler<GetCustomerByIdQuery, Customer>
{
    public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        => await _provider.GetCustomerById(request.Id);
}