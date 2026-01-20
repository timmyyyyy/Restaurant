namespace Restaurant.IntegrationMessages;

public record PaymentFailedIntegrationEvent : IBaseOrderMessage
{
    public Guid OrderId { get; init; }
}
