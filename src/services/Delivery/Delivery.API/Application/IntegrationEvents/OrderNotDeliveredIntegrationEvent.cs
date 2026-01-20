namespace Delivery.API.Application.IntegrationEvents;

public record OrderNotDeliveredIntegrationEvent
{
    public Guid OrderId { get; init; }

    public required string Reason { get; init; }
}
