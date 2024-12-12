using FFCG.Eventful.Pizza.Place.Application.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;

namespace FFCG.Eventful.Pizza.Place.Domain.Services;

public interface IPizzaService
{
    Task<Models.Pizza> Create(string name, List<Topping> toppings);
}

public class PizzaService(IPizzaProvider _provider) : IPizzaService
{
    public async Task<Models.Pizza> Create(string name, List<Topping> toppings)
    {
        var allPizzaNames = (await _provider.GetAllPizzas()).Select(p => p.Name);
        var isNameTaken = allPizzaNames.Any(pn => pn == name);

        if (isNameTaken)
            throw new Exception($"Pizza name '{name}' is taken");

        return new Models.Pizza(name, toppings);
    }
}