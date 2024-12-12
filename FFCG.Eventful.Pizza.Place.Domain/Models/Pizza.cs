using System.Text.Json.Serialization;

namespace FFCG.Eventful.Pizza.Place.Domain.Models;

public class Pizza
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; private set; }
    public List<Topping> Toppings { get; private set; }
    public decimal Price => Toppings.Sum(t => t.Cost);

    internal Pizza(string name, List<Topping> toppings)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new Exception("Name cannot be null or empty");

        Name = name;
        Toppings = toppings;
    }

    [JsonConstructor]
    protected Pizza()
    {
        Name = "";
        Toppings = [];
    }
}