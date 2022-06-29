using System;
using System.Threading.Tasks;
using FFCG.Eventful.Pizza.Place.Application.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using FFCG.Eventful.Pizza.Place.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FFCG.Eventful.Pizza.Place.Worker.Functions.CreateOrder3rdPartyMock;

public class CreateOrderFunction
{
    private readonly IMessagingClient _messagingClient;

    public CreateOrderFunction(IMessagingClient messagingClient)
    {
        _messagingClient = messagingClient;
    }

    [Function(nameof(CreateOrderFunction))]
    public async Task Run([TimerTrigger("*/15 * * * * *")] TimerInfo timerInfo, FunctionContext context)
    {
        Console.WriteLine($"Creating new order...");

        var result = await _messagingClient.SendMessage(Subjects.OrderCreated, new Order());

        if (!result)
        {
            throw new Exception("Order could not be created");
        }
    }
}