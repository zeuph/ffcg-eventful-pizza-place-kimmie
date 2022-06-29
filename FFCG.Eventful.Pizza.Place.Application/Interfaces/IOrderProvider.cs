using FFCG.Eventful.Pizza.Place.Domain.Models;

namespace FFCG.Eventful.Pizza.Place.Application.Interfaces;

public interface IOrderProvider
{
    public Task<Order> GetOrderById(Guid id);
    public Task<IEnumerable<Order>> GetAllOrders();
    public Task<Order> UpsertOrder(Order order);
}