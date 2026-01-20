namespace Restaurant.IntegrationMessages;

public record OrderValidatedSuccessfullyIntegrationEvent
{
    public Guid OrderId { get; private set; }
}
