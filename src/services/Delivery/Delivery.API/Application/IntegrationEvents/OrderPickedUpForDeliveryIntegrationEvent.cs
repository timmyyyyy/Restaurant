namespace Delivery.API.Application.IntegrationEvents
{
    public record OrderPickedUpForDeliveryIntegrationEvent
    {
        public Guid OrderId { get; init; }
    }
}
