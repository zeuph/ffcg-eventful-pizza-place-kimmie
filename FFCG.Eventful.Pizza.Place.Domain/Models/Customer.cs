namespace FFCG.Eventful.Pizza.Place.Domain.Models;

public class Customer
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string Name { get; init; }
    public required string PhoneNumber { get; init; }
    public required string Email { get; init; }
}
