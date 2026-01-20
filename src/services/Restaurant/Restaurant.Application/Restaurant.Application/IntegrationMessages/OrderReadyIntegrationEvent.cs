namespace Restaurant.IntegrationMessages;

public record OrderReadyIntegrationEvent
{
    public Guid OrderId { get; init; }
}
