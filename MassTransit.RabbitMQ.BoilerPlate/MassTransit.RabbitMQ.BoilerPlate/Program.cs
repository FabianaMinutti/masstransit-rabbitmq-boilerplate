using MassTransit;
using MassTransit.RabbitMQ.BoilerPlate.Consumer;
using MassTransit.RabbitMQ.BoilerPlate.Publisher;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMassTransit(busConfiguration =>
{
    busConfiguration.SetKebabCaseEndpointNameFormatter();

    busConfiguration.AddConsumer<MessageConsumer>();

    busConfiguration.UsingRabbitMq((context, config) =>
    {
        config.Host(new Uri(builder.Configuration["MessageBroker:Host"]!), h =>
        {
            h.Username(builder.Configuration["MessageBroker:UserName"]!);
            h.Password(builder.Configuration["MessageBroker:Password"]!);
        });

        config.ConfigureEndpoints(context);
    });

    //busConfiguration.UsingInMemory((context, config) => config.ConfigureEndpoints(context));
});

builder.Services.AddHostedService<MessagePublisher>();

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
