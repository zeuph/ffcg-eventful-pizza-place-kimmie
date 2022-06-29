using FFCG.Eventful.Pizza.Place.Application.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using MediatR;

namespace FFCG.Eventful.Pizza.Place.Application.Features.GetOrderById;

public class GetOrderByIdQuery : IRequest<Order>
{
    public GetOrderByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Order>
{
    private readonly IOrderProvider _orderProvider;

    public GetOrderByIdHandler(IOrderProvider orderProvider)
    {
        _orderProvider = orderProvider;
    }

    public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _orderProvider.GetOrderById(request.Id);

        return result;
    }
}