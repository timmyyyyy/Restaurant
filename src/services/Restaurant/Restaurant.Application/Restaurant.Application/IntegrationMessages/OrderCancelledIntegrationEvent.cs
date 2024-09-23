namespace Restaurant.IntegrationMessages
{
    public record OrderCancelledIntegrationEvent
    {
        public Guid OrderId { get; init; }
    }
}
