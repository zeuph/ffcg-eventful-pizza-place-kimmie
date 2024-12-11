using FFCG.Eventful.Pizza.Place.Application.Features.GetAllCustomers;
using FFCG.Eventful.Pizza.Place.Application.Features.GetCustomerById;
using FFCG.Eventful.Pizza.Place.Controllers.Customers.ApiModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FFCG.Eventful.Pizza.Place.Controllers.Customers;

[ApiController]
[Route("[controller]")]
public class CustomerController(ISender _sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateNewCustomerApiModel model)
    {
        var result = await _sender.Send(model.MapToCommand());
        return Created(result.Id.ToString(), result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
        => Ok(await _sender.Send(new GetAllCustomersQuery()));

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetCustomerById(Guid id)
        => Ok(await _sender.Send(new GetCustomerByIdQuery(id)));
}