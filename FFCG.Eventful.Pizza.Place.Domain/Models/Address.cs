namespace FFCG.Eventful.Pizza.Place.Domain.Models;

public class Address
{
    public required string Street { get; init; }
    public required string StreetNumber { get; init; }
    public required string ZipCode { get; init; }
    public required string City { get; init; }
    public required string Country { get; init; }
}