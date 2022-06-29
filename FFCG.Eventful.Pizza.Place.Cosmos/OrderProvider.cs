using FFCG.Eventful.Pizza.Place.Application.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace FFCG.Eventful.Pizza.Place.Cosmos.Providers;

public class OrderProvider : IOrderProvider
{
    private readonly Container _container;

    public OrderProvider(CosmosClient cosmosClient)
    {
        _container = cosmosClient.GetContainer("ffcg-eventful-pizza-place", "orders");
    }

    public async Task<Order> GetOrderById(Guid id)
    {
        return await _container.ReadItemAsync<Order>(id.ToString(), new PartitionKey(id.ToString()));
    }

    public async Task<IEnumerable<Order>> GetAllOrders()
    {
        var iterator = _container
            .GetItemLinqQueryable<Order>()
            .Where(x => x.Id != Guid.Empty);

        return await iterator.ToFeedIterator().ReadNextAsync();
    }

    public async Task<Order> UpsertOrder(Order order)
    {
        var result = await _container.UpsertItemAsync(
            order,
            new PartitionKey(order.Id.ToString())
        );

        return result.Resource;
    }
}