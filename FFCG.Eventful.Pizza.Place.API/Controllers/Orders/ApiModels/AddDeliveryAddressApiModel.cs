using FFCG.Eventful.Pizza.Place.Domain.Models;

namespace FFCG.Eventful.Pizza.Place.Controllers.Orders.ApiModels;

public record AddDeliveryAddressToOrderApiModel(string Street, string StreetNumber, string ZipCode, string City, string Country)
{
    public Address MapToEntity()
    {
        return new Address()
        {
            Street = Street,
            StreetNumber = StreetNumber,
            ZipCode = ZipCode,
            City = City,
            Country = Country
        };
    }
}