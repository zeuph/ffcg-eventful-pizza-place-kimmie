using Azure.Messaging.ServiceBus;
using FFCG.Eventful.Pizza.Place.Application.Features.CreateNewOrder;
using FFCG.Eventful.Pizza.Place.Application.Interfaces;
using FFCG.Eventful.Pizza.Place.Cosmos.Providers;
using MediatR;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(CreateNewOrderHandler).Assembly);
builder.Services.AddScoped<IOrderProvider, OrderProvider>();

const string serviceBusConnectionString = "Endpoint=sb://ffcg-eventful-pizza-place.servicebus.windows.net/;SharedAccessKeyName=AccessPolicy;SharedAccessKey=A5dAZQxmaAv3HkufGCPFDmEM/t5zDg0a7bnm5WJvonE=;";
builder.Services.AddSingleton(s => new ServiceBusClient(serviceBusConnectionString));

const string cosmosConnString = "AccountEndpoint=https://ffcg-eventful-pizza-place.documents.azure.com:443/;AccountKey=Ohf1pAx3CEA5HXWv5JkWs6S4xaMXDdPdNm05jM6Qy2ydGTb10lohnym7Z74RtyWln2DRif1d4difA8kGSVRFKw==;";
builder.Services.AddSingleton(s => new CosmosClientBuilder(cosmosConnString)
    .WithConnectionModeDirect()
    .WithSerializerOptions(new CosmosSerializationOptions
    {
        PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
    })
    .Build());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();