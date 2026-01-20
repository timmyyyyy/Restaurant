namespace Restaurant.IntegrationMessages;

public record PaymentFailedIntegrationEvent
{
    public Guid OrderId { get; init; }
}
