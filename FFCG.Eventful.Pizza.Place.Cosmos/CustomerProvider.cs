using FFCG.Eventful.Pizza.Place.Application.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace FFCG.Eventful.Pizza.Place.Cosmos;

public class CustomerProvider : ICustomerProvider
{
    private readonly Container _container;

    public CustomerProvider(CosmosClient cosmosClient)
    {
        _container = cosmosClient.GetContainer("ffcg-eventful-pizza-place", "customer");
    }

    public async Task<Customer> GetCustomerById(Guid id)
    {
        return await _container.ReadItemAsync<Customer>(id.ToString(), new PartitionKey(id.ToString()));
    }

    public async Task<IEnumerable<Customer>> GetAllCustomers()
    {
        var iterator = _container
            .GetItemLinqQueryable<Customer>()
            .Where(x => x.Id != Guid.Empty);

        return await iterator.ToFeedIterator().ReadNextAsync();
    }

    public async Task<Customer> UpsertCustomer(Customer customer)
    {
        var result = await _container.UpsertItemAsync(
            customer,
            new PartitionKey(customer.Id.ToString())
        );

        return result.Resource;
    }

}