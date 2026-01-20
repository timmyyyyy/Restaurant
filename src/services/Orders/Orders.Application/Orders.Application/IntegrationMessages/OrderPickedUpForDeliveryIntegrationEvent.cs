
namespace Restaurant.IntegrationMessages;

public record OrderPickedUpForDeliveryIntegrationEvent : IBaseOrderMessage
{
    public Guid OrderId { get; init; }
}
