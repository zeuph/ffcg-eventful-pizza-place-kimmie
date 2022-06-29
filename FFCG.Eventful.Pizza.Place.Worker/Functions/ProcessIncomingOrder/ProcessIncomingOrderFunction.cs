using System;
using FFCG.Eventful.Pizza.Place.ServiceBus;
using Microsoft.Azure.Functions.Worker;

namespace FFCG.Eventful.Pizza.Place.Worker.Functions.ProcessIncomingOrder;

public class ProcessIncomingOrderFunction
{
    [Function(nameof(ProcessIncomingOrderFunction))]
    public void Run(
        [ServiceBusTrigger(Topics.Orders, "worker-incoming-order", Connection = "ServiceBusConnectionStringOrders")] IncomingOrderMessage incomingOrder)
    {
        Console.WriteLine("Order körs");
    }
}