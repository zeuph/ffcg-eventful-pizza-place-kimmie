using FFCG.Eventful.Pizza.Place.Application.Features.GetAllPizzas;
using FFCG.Eventful.Pizza.Place.Application.Features.GetPizzaById;
using FFCG.Eventful.Pizza.Place.Controllers.Pizzas.ApiModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FFCG.Eventful.Pizza.Place.Controllers.Pizzas;

[ApiController]
[Route("pizzas")]
public class PizzaController(ISender _sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePizza([FromBody] CreateNewPizzaApiModel model)
    {
        var result = await _sender.Send(model.MapToCommand());
        return Created(result.Id.ToString(), result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPizzas()
    {
        return Ok(await _sender.Send(new GetAllPizzasQuery()));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetPizzaById(Guid id)
    {
        return Ok(await _sender.Send(new GetPizzaByIdQuery(id)));
    }
}
