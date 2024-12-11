namespace FFCG.Eventful.Pizza.Place.Domain.Models;

public class Order
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid? CustomerId { get; set; }
    public Address? DeliveryAddress { get; set; }
    public List<Guid> PizzaIds { get; set; } = [];
}