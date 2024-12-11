using FFCG.Eventful.Pizza.Place.Application.Features.CreateNewPizza;
using FFCG.Eventful.Pizza.Place.Domain.Models;

namespace FFCG.Eventful.Pizza.Place.Controllers.Pizza.ApiModels;

public record CreateNewPizzaApiModel(string Name, List<ToppingApiModel> Toppings)
{
    public CreateNewPizzaCommand MapToCommand()
    {
        return new CreateNewPizzaCommand()
        {
            Name = Name,
            Toppings = Toppings.Select(t => new Topping()
            {
                Name = t.Name,
                Cost = t.Price
            }).ToList()
        };
    }
}