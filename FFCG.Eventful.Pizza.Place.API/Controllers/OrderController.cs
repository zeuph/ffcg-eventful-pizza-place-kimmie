using FFCG.Eventful.Pizza.Place.Application.Features.CreateNewOrder;
using FFCG.Eventful.Pizza.Place.Application.Features.GetAllOrdersQuery;
using FFCG.Eventful.Pizza.Place.Application.Features.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FFCG.Eventful.Pizza.Place.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly ISender _mediatrSender;

    public OrderController(ISender mediatrSender)
    {
        _mediatrSender = mediatrSender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateNewOrderCommand command)
    {
        var result = await _mediatrSender.Send(command);
        return Created(result.Id.ToString(), result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var result = await _mediatrSender.Send(new GetAllOrdersQuery());
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetOrderById(Guid id)
    {
        var result = await _mediatrSender.Send(new GetOrderByIdQuery(id));
        return Ok(result);
    }
}