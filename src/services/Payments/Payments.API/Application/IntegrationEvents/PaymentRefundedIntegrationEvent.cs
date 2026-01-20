namespace Restaurant.IntegrationMessages;

public record PaymentRefundedIntegrationEvent
{
    public Guid OrderId { get; init; }
}
