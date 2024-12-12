using Azure.Messaging.ServiceBus;
using FFCG.Eventful.Pizza.Place.Application.Features.CreateNewOrder;
using FFCG.Eventful.Pizza.Place.Application.Interfaces;
using FFCG.Eventful.Pizza.Place.Cosmos;
using FFCG.Eventful.Pizza.Place.Cosmos.Providers;
using FFCG.Eventful.Pizza.Place.Domain.Services;
using MediatR;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(CreateNewOrderHandler).Assembly);
builder.Services.AddScoped<IOrderProvider, OrderProvider>();
builder.Services.AddScoped<IPizzaProvider, PizzaProvider>();
builder.Services.AddScoped<ICustomerProvider, CustomerProvider>();
builder.Services.AddScoped<IPizzaService, PizzaService>();

builder.Services.AddSingleton(s => new ServiceBusClient(builder.Configuration.GetValue<string>("ServiceBus:ConnectionString")));

builder.Services.AddSingleton(s => new CosmosClientBuilder(builder.Configuration.GetValue<string>("Cosmos:Url"), builder.Configuration.GetValue<string>("Cosmos:Key"))
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