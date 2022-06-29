using System;
using FFCG.Eventful.Pizza.Place.Application.Interfaces;
using FFCG.Eventful.Pizza.Place.ServiceBus;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FFCG.Eventful.Pizza.Place.Worker
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults(builder =>
                {
                    builder.Services.AddAzureClients(azureClientsBuilder =>
                    {
                        azureClientsBuilder.AddServiceBusClient(
                            Environment.GetEnvironmentVariable("ServiceBusConnectionStringOrders"));
                    });

                    builder.Services.AddScoped<IMessagingClient, ServiceBusSenderService>();
                }).Build();

            host.Run();
        }
    }
}