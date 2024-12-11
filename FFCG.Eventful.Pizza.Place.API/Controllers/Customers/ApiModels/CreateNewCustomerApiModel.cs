using FFCG.Eventful.Pizza.Place.Application.Features.CreateNewCustomer;

namespace FFCG.Eventful.Pizza.Place.Controllers.Customers.ApiModels;

public record CreateNewCustomerApiModel(string Name, string Email, string PhoneNumber)
{
    public CreateNewCustomerCommand MapToCommand()
        => new(Name, Email, PhoneNumber);
}