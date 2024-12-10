using FFCG.Eventful.Pizza.Place.Application.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using MediatR;

namespace FFCG.Eventful.Pizza.Place.Application.Features.CreateNewCustomer;

public record CreateNewCustomerCommand(string Name, string Email, string PhoneNumber) : IRequest<Customer>;

public class CreateNewCustomerHandler(ICustomerProvider _provider)
{
    public async Task<Customer> Handle(CreateNewCustomerCommand request)
    {
        return await _provider.UpsertCustomer(new Customer()
        {
            Name = request.Name,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
        });
    }
}