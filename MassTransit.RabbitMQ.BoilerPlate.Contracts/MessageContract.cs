namespace MassTransit.RabbitMQ.BoilerPlate.Contracts
{
    public record MessageContract
    {
        public string Value { get; init; } = string.Empty;
    }
}
