namespace Delivery.API.Application.IntegrationEvents;

public record OrderDeliveredIntegrationEvent
{
    public Guid OrderId { get; init; }
}
