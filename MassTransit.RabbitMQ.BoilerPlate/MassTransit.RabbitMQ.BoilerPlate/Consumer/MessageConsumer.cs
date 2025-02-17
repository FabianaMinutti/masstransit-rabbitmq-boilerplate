using MassTransit.RabbitMQ.BoilerPlate.Contracts;

namespace MassTransit.RabbitMQ.BoilerPlate.Consumer
{
    public class MessageConsumer(ILogger<MessageConsumer> _logger) : IConsumer<MessageContract>
    {
        public Task Consume(ConsumeContext<MessageContract> context)
        {
            _logger.LogInformation("{Consumer}: {Message}", nameof(MessageConsumer), context.Message.Value);

            return Task.CompletedTask;
        }
    }
}
