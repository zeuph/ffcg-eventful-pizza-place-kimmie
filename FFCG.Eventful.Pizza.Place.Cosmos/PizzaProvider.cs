using FFCG.Eventful.Pizza.Place.Application.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace FFCG.Eventful.Pizza.Place.Cosmos;

public class PizzaProvider : IPizzaProvider
{
    private readonly Container _container;

    public PizzaProvider(CosmosClient cosmosClient)
    {
        _container = cosmosClient.GetContainer("ffcg-eventful-pizza-place", "pizzas");
    }

    public async Task<Domain.Models.Pizza> GetPizzaById(Guid id)
    {
        return await _container.ReadItemAsync<Domain.Models.Pizza>(id.ToString(), new PartitionKey(id.ToString()));
    }

    public async Task<IEnumerable<Domain.Models.Pizza>> GetAllPizzas()
    {
        var iterator = _container
            .GetItemLinqQueryable<Domain.Models.Pizza>()
            .Where(x => x.Id != Guid.Empty);

        return await iterator.ToFeedIterator().ReadNextAsync();
    }

    public async Task<Domain.Models.Pizza> UpsertPizza(Domain.Models.Pizza pizza)
    {
        var result = await _container.UpsertItemAsync(
            pizza,
            new PartitionKey(pizza.Id.ToString())
        );

        return result.Resource;
    }

}