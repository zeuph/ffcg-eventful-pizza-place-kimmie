using FFCG.Eventful.Pizza.Place.Application.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using MediatR;

namespace FFCG.Eventful.Pizza.Place.Application.Features.CreateNewOrder;

public class CreateNewOrderCommand : IRequest<Order>
{
    
}

public class CreateNewOrderHandler : IRequestHandler<CreateNewOrderCommand, Order>
{
    private readonly IOrderProvider _orderProvider;

    public CreateNewOrderHandler(IOrderProvider orderProvider)
    {
        _orderProvider = orderProvider;
    }

    public async Task<Order> Handle(CreateNewOrderCommand request, CancellationToken cancellationToken)
    {
        var result = await _orderProvider.UpsertOrder(new Order());

        return result;
    }
}