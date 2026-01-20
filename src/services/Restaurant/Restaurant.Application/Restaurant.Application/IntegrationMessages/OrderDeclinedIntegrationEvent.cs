namespace Restaurant.IntegrationMessages;

public record OrderDeclinedIntegrationEvent
{
    public Guid OrderId { get; init; }

    public required string Reason { get; init; }
}
