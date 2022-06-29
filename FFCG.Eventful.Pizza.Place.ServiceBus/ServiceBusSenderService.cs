using System.Net.Mime;
using Azure.Messaging.ServiceBus;
using FFCG.Eventful.Pizza.Place.Application.Interfaces;

namespace FFCG.Eventful.Pizza.Place.ServiceBus;

public class ServiceBusSenderService : IMessagingClient
{
    private readonly ServiceBusSender _serviceBusSender;

    public ServiceBusSenderService(ServiceBusClient serviceBusClient)
    {
        _serviceBusSender = serviceBusClient
            .CreateSender(Topics.Orders);
    }

    public async Task<bool> SendMessage<T>(string subject, T data)
    {
        var message = new ServiceBusMessage
        {
            Subject = subject,
            Body = new BinaryData(data),
            ContentType = MediaTypeNames.Application.Json
        };

        try
        {
            await _serviceBusSender.SendMessageAsync(message);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Send Message failed with error: {e.Message}");
            return false;
        }

        return true;
    }
}