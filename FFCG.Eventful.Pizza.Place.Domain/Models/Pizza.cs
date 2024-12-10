namespace FFCG.Eventful.Pizza.Place.Domain.Models;

public class Pizza
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string Name { get; init; }
    public required List<Topping> Toppings { get; init; }
    public decimal Price => Toppings.Sum(t => t.Cost);
}
