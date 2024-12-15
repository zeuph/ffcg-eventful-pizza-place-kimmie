using FFCG.Eventful.Pizza.Place.Application.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using MediatR;

namespace FFCG.Eventful.Pizza.Place.Application.Features.CreateNewOrder;

public class CreateNewOrderCommand : IRequest<Order>
{

}

public class CreateNewOrderHandler(IOrderProvider _orderProvider) : IRequestHandler<CreateNewOrderCommand, Order>
{
    public async Task<Order> Handle(CreateNewOrderCommand request, CancellationToken cancellationToken)
    {
        var result = await _orderProvider.UpsertOrder(new Order());

        await _mediator.Publish(
            new OrderCreatedEvent(result.Id, result.CustomerEmail),
            cancellationToken
        );
        return result;
    }
}