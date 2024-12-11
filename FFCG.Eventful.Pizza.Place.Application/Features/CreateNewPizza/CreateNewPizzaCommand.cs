using FFCG.Eventful.Pizza.Place.Application.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using MediatR;

namespace FFCG.Eventful.Pizza.Place.Application.Features.CreateNewPizza;

public class CreateNewPizzaCommand : IRequest<Domain.Models.Pizza>
{
    public required string Name { get; init; }
    public required List<Topping> Toppings { get; init; }
}

public class CreateNewPizzaHandler(IPizzaProvider _pizzaProvider) : IRequestHandler<CreateNewPizzaCommand, Domain.Models.Pizza>
{
    public async Task<Domain.Models.Pizza> Handle(CreateNewPizzaCommand request, CancellationToken cancellationToken)
    {
        return await _pizzaProvider.UpsertPizza(new Domain.Models.Pizza()
        {
            Name = request.Name,
            Toppings = request.Toppings
        });
    }
}