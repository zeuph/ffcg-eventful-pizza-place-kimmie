using FFCG.Eventful.Pizza.Place.Application.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using MediatR;

namespace FFCG.Eventful.Pizza.Place.Application.Features.AddPizzaToOrder;

public record AddPizzaToOrderCommand(Guid OrderId, Guid PizzaId) : IRequest<Order>;

public class AddPizzaToOrderHandler(IOrderProvider _orderProvider, IPizzaProvider _pizzaProvider)
{
    public async Task<Order> Handle(AddPizzaToOrderCommand request)
    {
        var order = await _orderProvider.GetOrderById(request.OrderId);
        var pizza = await _pizzaProvider.GetPizzaById(request.PizzaId);

        order.Pizzas.Add(pizza);

        await _orderProvider.UpsertOrder(order);

        return order;
    }
}