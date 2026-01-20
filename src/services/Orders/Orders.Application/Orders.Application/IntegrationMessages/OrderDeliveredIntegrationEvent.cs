
namespace Restaurant.IntegrationMessages;

public record OrderDeliveredIntegrationEvent : IBaseOrderMessage
{
    public Guid OrderId { get; init; }
}
