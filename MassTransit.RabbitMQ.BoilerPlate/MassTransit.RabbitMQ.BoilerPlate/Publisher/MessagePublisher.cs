
using MassTransit.RabbitMQ.BoilerPlate.Contracts;

namespace MassTransit.RabbitMQ.BoilerPlate.Publisher
{
    public class MessagePublisher(IBus _bus) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                await _bus.Publish(new MessageContract
                {
                    Value = $"Mensagem publicada às {DateTime.UtcNow}"
                }, stoppingToken);

                await Task.Delay(1000, stoppingToken);
            }            
        }
    }

    
}
