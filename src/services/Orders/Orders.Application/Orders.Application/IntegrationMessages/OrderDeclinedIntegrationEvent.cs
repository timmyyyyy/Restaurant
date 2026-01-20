namespace Restaurant.IntegrationMessages;

public record OrderDeclinedIntegrationEvent : IBaseOrderMessage
{
    public Guid OrderId { get; init; }

    public required string Reason { get; init; }
}
