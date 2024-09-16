namespace Restaurant.Application.IntegrationMessages
{
    public record OrderCancelledIntegrationEvent
    {
        public Guid OrderId { get; init; }
    }
}
