namespace FFCG.Eventful.Pizza.Place.Domain.Models;

public class Order
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Customer? Customer { get; set; }
    public Address? DeliveryAddress { get; set; }
    public List<Pizza> Pizzas { get; set; } = [];
    public decimal TotalPrice => Pizzas.Sum(p => p.Price);
}