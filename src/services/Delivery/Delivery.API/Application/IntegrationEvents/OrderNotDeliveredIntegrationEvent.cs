namespace Delivery.API.Application.IntegrationEvents
{
    public record OrderNotDeliveredIntegrationEvent
    {
        public Guid OrderId { get; init; }

        public string Reason { get; init; }
    }
}
