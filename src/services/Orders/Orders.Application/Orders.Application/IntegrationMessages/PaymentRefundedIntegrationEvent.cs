
namespace Restaurant.IntegrationMessages;

public record PaymentRefundedIntegrationEvent : IBaseOrderMessage
{
    public Guid OrderId { get; init; }
}
