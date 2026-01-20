
namespace Restaurant.IntegrationMessages;

public record OrderNotDeliveredIntegrationEvent : IBaseOrderMessage
{
    public Guid OrderId { get; init; }

    public required string Reason { get; init; }
}
